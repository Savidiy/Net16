using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MainModule
{
    public sealed class MailBoxTab : MonoBehaviour
    {
        [SerializeField] private MailNameRow MailNameRow;
        [SerializeField] private Transform MailNameRowRoot;
        [SerializeField] private MailContent MailContent;

        private readonly List<MailNameRow> _mailNameRows = new();

        [Inject]
        public void Construct(Mailbox mailbox, IInstantiator instantiator)
        {
            for (var index = mailbox.Mails.Count - 1; index >= 0; index--)
            {
                Mail mail = mailbox.Mails[index];
                var mailNameRow = instantiator.InstantiatePrefabForComponent<MailNameRow>(MailNameRow, MailNameRowRoot);
                mailNameRow.Initialize(mail);
                mailNameRow.Selected += SelectMailRow;
                _mailNameRows.Add(mailNameRow);
            }

            SelectMailRow(_mailNameRows[0]);
        }

        private void SelectMailRow(MailNameRow selectedMailRow)
        {
            foreach (MailNameRow mailNameRow in _mailNameRows)
            {
                bool isSelected = mailNameRow == selectedMailRow;
                mailNameRow.SetSelected(isSelected);
                if (isSelected)
                    MailContent.Initialize(mailNameRow.Mail);
            }
        }
    }
}