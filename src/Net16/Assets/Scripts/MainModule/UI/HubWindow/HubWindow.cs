using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MainModule
{
    public sealed class HubWindow : BaseWindow
    {
        [SerializeField] private GameObject MailBoxNotification;
        [SerializeField] private Button MailBoxButton;
        [SerializeField] private MailBoxTab MailBoxTab;
        
        [Inject]
        public void Construct(Mailbox mailbox)
        {
            mailbox.HasNotification.Subscribe(OnMailboxHasNotificationChanged);
        }

        private void OnMailboxHasNotificationChanged(bool hasNotification)
        {
            MailBoxNotification.SetActive(hasNotification);
        }
    }
}