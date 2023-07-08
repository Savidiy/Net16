using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MainModule
{
    internal class LinkActionRow : MonoBehaviour
    {
        [SerializeField] private Button CollectButton;
        [SerializeField] private TMP_Text CollectText;
        [SerializeField] private TMP_Text Title;

        private CompositeDisposable _subscriptions;
        private MailAttachment _attachment;
        private AttachmentTypeTextProvider _attachmentTypeTextProvider;
        private ILinkStaticDataProvider _linkStaticDataProvider;
        private IFileStaticDataProvider _fileStaticDataProvider;

        private void Awake()
        {
            CollectButton.onClick.AddListener(OnCollect);
        }

        private void OnDestroy()
        {
            CollectButton.onClick.RemoveListener(OnCollect);
            _subscriptions?.Dispose();
        }

        [Inject]
        public void Construct(AttachmentTypeTextProvider attachmentTypeTextProvider,
            ILinkStaticDataProvider linkStaticDataProvider, IFileStaticDataProvider fileStaticDataProvider)
        {
            _fileStaticDataProvider = fileStaticDataProvider;
            _linkStaticDataProvider = linkStaticDataProvider;
            _attachmentTypeTextProvider = attachmentTypeTextProvider;
        }

        public void Initialize(MailAttachment attachment)
        {
            _attachment = attachment;
            _subscriptions?.Dispose();
            _subscriptions = new CompositeDisposable();


            Title.text = GetTitle(attachment.StaticData);
            CollectText.text = _attachmentTypeTextProvider.GetCollectText(attachment.StaticData.Type);
            attachment.WasReceived.Subscribe(OnWasReceivedChange).AddTo(_subscriptions);
        }

        private string GetTitle(AttachmentStaticData staticData)
        {
            return staticData.Type switch
            {
                AttachmentType.Link => _linkStaticDataProvider.GetData(staticData.LinkId).Address,
                AttachmentType.File => _fileStaticDataProvider.GetData(staticData.FileId).DownloadMailName,
                _ => throw new ArgumentOutOfRangeException()
            };
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