using Sirenix.OdinInspector;

namespace MainModule
{
    public static class OdinMailIdsProvider
    {
        private static readonly EditorScriptableObjectLoader<MailStaticDataLibrary> Loader = new();
        public static ValueDropdownList<string> AvailableMailIds => Loader.GetAsset().AvailableMailIds;
    }
}