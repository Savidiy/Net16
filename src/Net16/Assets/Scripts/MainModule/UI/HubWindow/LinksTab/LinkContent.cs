using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

namespace MainModule
{
    internal class LinkContent : MonoBehaviour
    {
        [SerializeField] private TMP_Text Title;
        [SerializeField] private TMP_Text Description;
        [SerializeField] private LinkActionRow LinkActionRowPrefab;
        [SerializeField] private Transform Root;

        private readonly List<LinkActionRow> _linkActionRows = new();
        private IInstantiator _instantiator;
        private TextTagFilter _textTagFilter;

        [Inject]
        public void Construct(IInstantiator instantiator, TextTagFilter textTagFilter)
        {
            _textTagFilter = textTagFilter;
            _instantiator = instantiator;
        }

        public void Initialize(Link link)
        {
            ClearActions();
            Title.text = link.StaticData.Name;
            Description.text = _textTagFilter.Filter(link.StaticData.Description);

            // foreach (LinkAttachment attachment in link.Attachments)
            // {
            //     var attachmentRow = _instantiator.InstantiatePrefabForComponent<AttachmentRow>(LinkActionRowPrefab, Root);
            //     attachmentRow.Initialize(attachment);
            //     _attachmentRows.Add(attachmentRow);
            // }
        }

        private void ClearActions()
        {
            foreach (LinkActionRow linkActionRow in _linkActionRows)
                Destroy(linkActionRow.gameObject);

            _linkActionRows.Clear();
        }
    }
}