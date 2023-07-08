using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace MainModule
{
    [CreateAssetMenu(fileName = nameof(LinksStaticDataLibrary), menuName = nameof(LinksStaticDataLibrary), order = 0)]
    public class LinksStaticDataLibrary : AutoSaveScriptableObject, ILinkStaticDataProvider
    {
        [SerializeField] private List<LinkStaticData> Links;

        public ValueDropdownList<string> AvailableLinkIds { get; } = new();

        protected override void OnValidate()
        {
            base.OnValidate();

            AvailableLinkIds.Clear();
            foreach (LinkStaticData file in Links)
                AvailableLinkIds.Add(file.Id);
        }

        public LinkStaticData GetData(string linkId)
        {
            foreach (LinkStaticData link in Links)
            {
                if (link.Id == linkId)
                    return link;
            }

            throw new Exception($"Link with id '{linkId}' not found");
        }
    }

    [Serializable]
    public class LinkStaticData
    {
        public string Id = "";
        public string Name;
        [FormerlySerializedAs("DownloadMailName")] public string Address;

        [TextArea(1, 20)] public string Description;
    }
}