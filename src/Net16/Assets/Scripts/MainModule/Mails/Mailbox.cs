using System.Collections.Generic;

namespace MainModule
{
    public sealed class Mailbox
    {
        public IReadOnlyList<Mail> Mails => _mails;
        private readonly List<Mail> _mails = new List<Mail>();

        public void AddMail(Mail mail)
        {
            _mails.Add(mail);
        }
    }
}