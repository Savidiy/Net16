using Sirenix.OdinInspector;

namespace MainModule
{
    public static class OdinLinkIdsProvider
    {
        private static readonly EditorScriptableObjectLoader<LinksStaticDataLibrary> Loader = new();
        public static ValueDropdownList<string> AvailableLinkIds => Loader.GetAsset().AvailableLinkIds;
    }
}