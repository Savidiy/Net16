using System.Collections.Generic;
using UniRx;

namespace MainModule
{
    public sealed class Mailbox
    {
        private readonly List<Mail> _mails = new();
        private readonly ReactiveProperty<bool> _hasNotification = new();

        public IReadOnlyReactiveProperty<bool> HasNotification => _hasNotification;
        public IReadOnlyList<Mail> Mails => _mails;

        public void AddMail(Mail mail)
        {
            _mails.Add(mail);
            mail.HasNotification.Subscribe(OnMailHasNotificationChanged);
        }

        private void OnMailHasNotificationChanged(bool _)
        {
            foreach (Mail mail in _mails)
            {
                if (mail.HasNotification.Value)
                {
                    _hasNotification.Value = true;
                    return;
                }
            }

            _hasNotification.Value = false;
        }
    }
}