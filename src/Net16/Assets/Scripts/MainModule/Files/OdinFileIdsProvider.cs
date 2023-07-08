using Sirenix.OdinInspector;

namespace MainModule
{
    public static class OdinFileIdsProvider
    {
        private static readonly EditorScriptableObjectLoader<FilesStaticDataLibrary> Loader = new();
        public static ValueDropdownList<string> AvailableFileIds => Loader.GetAsset().AvailableFileIds;
    }
}