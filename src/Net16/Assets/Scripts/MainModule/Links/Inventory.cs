using System;
using System.Collections.Generic;
using UniRx;

namespace MainModule
{
    public sealed class Inventory
    {
        private readonly ILinkStaticDataProvider _linkStaticDataProvider;
        private readonly List<string> _fileIds = new();
        private readonly List<Link> _links = new();
        private readonly ReactiveProperty<bool> _hasNotification = new();

        public IReadOnlyList<string> FileIds => _fileIds;
        public IReadOnlyList<Link> Links => _links;
        public IReadOnlyReactiveProperty<bool> HasNotification => _hasNotification;

        public event Action OnChanged;

        public Inventory(ILinkStaticDataProvider linkStaticDataProvider)
        {
            _linkStaticDataProvider = linkStaticDataProvider;
        }

        public void Add(AttachmentStaticData attachmentStaticData)
        {
            switch (attachmentStaticData.Type)
            {
                case AttachmentType.Link:
                    string linkId = attachmentStaticData.LinkId;
                    LinkStaticData linkStaticData = _linkStaticDataProvider.GetData(linkId);
                    var link = new Link(linkStaticData);
                    _links.Add(link);
                    link.WasRead.Subscribe(OnWasReadChange);
                    InvokeChanged();
                    break;
                case AttachmentType.File:
                    _fileIds.Add(attachmentStaticData.FileId);
                    InvokeChanged();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void OnWasReadChange(bool _)
        {
            foreach (Link link in _links)
            {
                if (!link.WasRead.Value)
                {
                    _hasNotification.Value = true;
                    return;
                }
            }

            _hasNotification.Value = false;
        }

        private void InvokeChanged()
        {
            OnChanged?.Invoke();
        }
    }
}