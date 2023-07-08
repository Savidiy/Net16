using Sirenix.OdinInspector;

namespace MainModule
{
    public static class MailIdsProvider
    {
        private static readonly EditorScriptableObjectLoader<MailStaticDataLibrary> Loader = new();
        public static ValueDropdownList<string> AvailableMailIds => Loader.GetAsset().AvailableMailIds;
    }
}