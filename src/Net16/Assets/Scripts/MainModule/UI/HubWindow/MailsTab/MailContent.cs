using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

namespace MainModule
{
    internal class MailContent : MonoBehaviour
    {
        [SerializeField] private TMP_Text From;
        [SerializeField] private TMP_Text To;
        [SerializeField] private TMP_Text Title;
        [SerializeField] private TMP_Text Message;
        [SerializeField] private AttachmentRow AttachmentRowPrefab;
        [SerializeField] private Transform Root;

        private readonly List<AttachmentRow> _attachmentRows = new();
        private IInstantiator _instantiator;

        [Inject]
        public void Construct(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public void Initialize(Mail mail)
        {
            ClearAttachments();
            From.text = $"From: {mail.StaticData.Sender}";
            To.text = $"To: {mail.StaticData.Receiver}";
            Title.text = $"Title: {mail.StaticData.Title}";
            Message.text = mail.StaticData.Message;

            foreach (MailAttachment attachment in mail.Attachments)
            {
                var attachmentRow = _instantiator.InstantiatePrefabForComponent<AttachmentRow>(AttachmentRowPrefab, Root);
                attachmentRow.Initialize(attachment);
                _attachmentRows.Add(attachmentRow);
            }
        }

        private void ClearAttachments()
        {
            foreach (AttachmentRow attachmentRow in _attachmentRows)
                Destroy(attachmentRow.gameObject);

            _attachmentRows.Clear();
        }
    }
}