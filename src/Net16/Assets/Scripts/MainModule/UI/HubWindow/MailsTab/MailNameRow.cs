using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace MainModule
{
    internal class MailNameRow : MonoBehaviour
    {
        private CompositeDisposable _subscriptions;

        [SerializeField] private GameObject NewMailIcon;
        [SerializeField] private TMP_Text Title;
        [SerializeField] private TMP_Text From;
        [SerializeField] private Button SelectButton;

        public Mail Mail { get; private set; }
        public event Action<MailNameRow> Selected;

        private void Awake()
        {
            SelectButton.onClick.AddListener(OnSelected);
        }

        public void Initialize(Mail mail)
        {
            _subscriptions?.Dispose();
            _subscriptions = new CompositeDisposable();

            Mail = mail;
            Title.text = mail.StaticData.Title;
            From.text = $"From: {mail.StaticData.Sender}";

            Mail.HasNotification.Subscribe(OnHasNotificationChange).AddTo(_subscriptions);
        }

        private void OnHasNotificationChange(bool hasNotification)
        {
            NewMailIcon.SetActive(hasNotification);
        }

        public void SetSelected(bool isSelected)
        {
            if (isSelected)
                Mail.MarkRead();

            SelectButton.interactable = !isSelected;
        }

        protected virtual void OnSelected()
        {
            Selected?.Invoke(this);
        }
    }
}