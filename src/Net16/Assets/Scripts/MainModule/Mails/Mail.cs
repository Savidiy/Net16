using System.Collections.Generic;
using UniRx;

namespace MainModule
{
    public class Mail : DisposableCollector
    {
        private readonly ReactiveProperty<bool> _hasNotification = new();
        private bool _wasRead;

        public IReadOnlyList<MailAttachment> Attachments { get; }
        public MailStaticData StaticData { get; }
        public IReadOnlyReactiveProperty<bool> HasNotification => _hasNotification;

        public Mail(MailStaticData staticData, List<MailAttachment> attachments)
        {
            Attachments = attachments;
            StaticData = staticData;
            
            foreach (MailAttachment mailAttachment in Attachments)
                AddDisposable(mailAttachment.WasReceived.Subscribe(OnWasReceivedChanged));
            
            UpdateNotification();
        }

        private void OnWasReceivedChanged(bool _)
        {
            UpdateNotification();
        }

        public void MarkRead()
        {
            _wasRead = true;
            UpdateNotification();
        }

        private void UpdateNotification()
        {
            _hasNotification.Value = !_wasRead || HasNotReceivedAttachments();
        }

        private bool HasNotReceivedAttachments()
        {
            foreach (MailAttachment mailAttachment in Attachments)
            {
                if (!mailAttachment.WasReceived.Value)
                    return true;
            }

            return false;
        }
    }
}