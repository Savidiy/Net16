using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MainModule
{
    [CreateAssetMenu(fileName = nameof(InitialProgressData), menuName = nameof(InitialProgressData), order = 0)]
    public class InitialProgressData : ScriptableObject
    {
        public List<MailId> StartMails;
    }

    [Serializable]
    public class MailId
    {
        [ValueDropdown(nameof(AvailableMailsId)), HideLabel] public string Id;
        private ValueDropdownList<string> AvailableMailsId => MailIdsProvider.AvailableMailIds;
    }
}