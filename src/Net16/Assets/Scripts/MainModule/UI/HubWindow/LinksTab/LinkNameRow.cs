using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace MainModule
{
    internal sealed class LinkNameRow : MonoBehaviour
    {
        private CompositeDisposable _subscriptions;

        [SerializeField] private GameObject NewLinkIcon;
        [SerializeField] private TMP_Text Title;
        [SerializeField] private TMP_Text Address;
        [SerializeField] private Button SelectButton;

        public Link Link { get; private set; }
        public event Action<LinkNameRow> Selected;

        private void Awake()
        {
            SelectButton.onClick.AddListener(OnSelected);
        }

        public void Initialize(Link link)
        {
            _subscriptions?.Dispose();
            _subscriptions = new CompositeDisposable();

            Link = link;
            Title.text = link.StaticData.Name;
            Address.text = link.StaticData.Address;

            Link.WasRead.Subscribe(OnWasReadChange).AddTo(_subscriptions);
        }

        private void OnWasReadChange(bool wasRead)
        {
            NewLinkIcon.SetActive(!wasRead);
        }

        public void SetSelected(bool isSelected)
        {
            if (isSelected)
                Link.MarkRead();

            SelectButton.interactable = !isSelected;
        }

        private void OnSelected()
        {
            Selected?.Invoke(this);
        }
    }
}