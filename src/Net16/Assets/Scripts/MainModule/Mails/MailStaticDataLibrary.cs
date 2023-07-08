using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MainModule
{
    [CreateAssetMenu(fileName = nameof(MailStaticDataLibrary), menuName = nameof(MailStaticDataLibrary), order = 0)]
    public class MailStaticDataLibrary : AutoSaveScriptableObject, IMailStaticDataProvider
    {
        [SerializeField, ListDrawerSettings(ListElementLabelName = "@this")] private List<MailStaticData> Mails;

        public ValueDropdownList<string> AvailableMailIds { get; } = new();

        protected override void OnValidate()
        {
            base.OnValidate();

            AvailableMailIds.Clear();
            foreach (MailStaticData mail in Mails)
                AvailableMailIds.Add(mail.Id);
        }

        public MailStaticData GetMailStaticData(string mailId)
        {
            foreach (MailStaticData mailStaticData in Mails)
            {
                if (mailStaticData.Id == mailId)
                    return mailStaticData;
            }

            throw new Exception($"Mail with id '{mailId}' not found");
        }
    }

    [Serializable]
    public class MailStaticData
    {
        public string Id = "";

        public string Sender;
        public string Receiver;
        public string Title;

        [TextArea(3, 10)]
        public string Message;

        public List<AttachmentStaticData> Attachments;

        public override string ToString()
        {
            return Id;
        }
    }

    [Serializable]
    public class AttachmentStaticData
    {
        [EnumToggleButtons] public AttachmentType Type;
        public string Value;
    }

    public enum AttachmentType
    {
        Link = 0,
        File = 1,
    }
}