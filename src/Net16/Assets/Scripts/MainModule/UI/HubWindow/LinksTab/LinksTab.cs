using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MainModule
{
    public sealed class LinksTab : MonoBehaviour
    {
        [SerializeField] private LinkNameRow LinkNameRow;
        [SerializeField] private Transform LinkNameRowRoot;
        [SerializeField] private LinkContent LinkContent;

        private readonly List<LinkNameRow> _linkNameRows = new();
        private Inventory _inventory;
        private IInstantiator _instantiator;

        [Inject]
        public void Construct(Inventory inventory, IInstantiator instantiator)
        {
            _instantiator = instantiator;
            _inventory = inventory;
            _inventory.OnChanged += UpdateLinks;

            UpdateLinks();
            SelectFirstLink();
        }

        public void SelectFirstLink()
        {
            if (_linkNameRows.Count > 0)
                SelectLinkRow(_linkNameRows[0]);
        }

        private void UpdateLinks()
        {
            for (int index = _linkNameRows.Count; index < _inventory.Links.Count; index++)
            {
                Link link = _inventory.Links[index];
                var linkNameRow = _instantiator.InstantiatePrefabForComponent<LinkNameRow>(LinkNameRow, LinkNameRowRoot);
                linkNameRow.Initialize(link);
                linkNameRow.Selected += SelectLinkRow;
                _linkNameRows.Add(linkNameRow);
            }
        }

        private void SelectLinkRow(LinkNameRow selectedLinkRow)
        {
            foreach (LinkNameRow linkNameRow in _linkNameRows)
            {
                bool isSelected = linkNameRow == selectedLinkRow;
                linkNameRow.SetSelected(isSelected);
                if (isSelected)
                    LinkContent.Initialize(linkNameRow.Link);
            }
        }
    }
}