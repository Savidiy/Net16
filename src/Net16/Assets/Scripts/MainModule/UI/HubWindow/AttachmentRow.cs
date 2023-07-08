﻿using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace MainModule
{
    internal class AttachmentRow : MonoBehaviour
    {
        [SerializeField] private Button CollectButton;
        [SerializeField] private TMP_Text CollectText;
        [SerializeField] private TMP_Text Title;

        private CompositeDisposable _subscriptions;
        private MailAttachment _attachment;

        private void Awake()
        {
            CollectButton.onClick.AddListener(OnCollect);
        }

        private void OnDestroy()
        {
            CollectButton.onClick.RemoveListener(OnCollect);
            _subscriptions?.Dispose();
        }

        public void Initialize(MailAttachment attachment)
        {
            _attachment = attachment;
            _subscriptions?.Dispose();
            _subscriptions = new CompositeDisposable();

            Title.text = attachment.StaticData.Value;
            CollectText.text = attachment.StaticData.Type;
            attachment.WasReceived.Subscribe(OnWasReceivedChange).AddTo(_subscriptions);
        }

        private void OnWasReceivedChange(bool wasReceived)
        {
            CollectButton.interactable = !wasReceived;
        }

        private void OnCollect()
        {
            _attachment?.Receive();
        }
    }
}