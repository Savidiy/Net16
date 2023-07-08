using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace MainModule
{
    [CreateAssetMenu(fileName = nameof(FilesStaticDataLibrary), menuName = nameof(FilesStaticDataLibrary), order = 0)]
    public class FilesStaticDataLibrary : AutoSaveScriptableObject, IFileStaticDataProvider
    {
        [SerializeField] private List<FileStaticData> Files;

        public ValueDropdownList<string> AvailableFileIds { get; } = new();

        protected override void OnValidate()
        {
            base.OnValidate();

            AvailableFileIds.Clear();
            foreach (FileStaticData file in Files)
                AvailableFileIds.Add(file.Id);
        }
        
        public FileStaticData GetData(string fileId)
        {
            foreach (FileStaticData file in Files)
            {
                if (file.Id == fileId)
                    return file;
            }

            throw new Exception($"File with id '{fileId}' not found");
        }
    }

    [Serializable]
    public class FileStaticData
    {
        public string Id = "";
        public string DownloadMailName;
    }
}