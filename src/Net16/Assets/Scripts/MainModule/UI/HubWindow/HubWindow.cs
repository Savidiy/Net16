using System.Collections.Generic;
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
        
        [SerializeField, Space] private GameObject LinksNotification;
        [SerializeField] private Button LinksButton;
        [SerializeField] private LinksTab LinksTab;
        
        [SerializeField, Space] private GameObject StartTab;
        
        private readonly List<GameObject> _tabs = new();
        private Inventory _inventory;

        protected override void OnAwake()
        {
            base.OnAwake();
            MailBoxButton.onClick.AddListener(OnMailBoxButtonClicked);
            LinksButton.onClick.AddListener(OnLinksButtonClicked);

            _tabs.Add(MailBoxTab.gameObject);
            _tabs.Add(LinksTab.gameObject);
            SelectTab(StartTab);
        }

        private void OnLinksButtonClicked()
        {
            LinksTab.SelectFirstLink();
            SelectTab(LinksTab.gameObject);
        }

        private void OnMailBoxButtonClicked()
        {
            SelectTab(MailBoxTab.gameObject);
        }

        private void SelectTab(GameObject selectedTab)
        {
            foreach (GameObject tab in _tabs)
            {
                tab.SetActive(tab == selectedTab);
            }
        }

        [Inject]
        public void Construct(Mailbox mailbox, Inventory inventory)
        {
            _inventory = inventory;
            
            mailbox.HasNotification.Subscribe(OnMailboxHasNotificationChanged);
            inventory.HasNotification.Subscribe(OnInventoryHasNotificationChanged);
            inventory.OnChanged += OnInventoryChanged;
            
            OnInventoryChanged();
        }

        private void OnInventoryChanged()
        {
            LinksButton.interactable = _inventory.Links.Count > 0;
        }

        private void OnInventoryHasNotificationChanged(bool hasNotification)
        {
            LinksNotification.SetActive(hasNotification);
        }

        private void OnMailboxHasNotificationChanged(bool hasNotification)
        {
            MailBoxNotification.SetActive(hasNotification);
        }
    }
}