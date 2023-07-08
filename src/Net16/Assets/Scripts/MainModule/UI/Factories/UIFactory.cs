using UnityEngine;
using Zenject;

namespace MainModule
{
    public sealed class UIFactory : IUIFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IWindowConfigProvider _windowConfigProvider;
        private const string UI_ROOT_PATH = "UIRoot";
    
        private Transform _uiRoot;

        public UIFactory(IInstantiator instantiator, IWindowConfigProvider windowConfigProvider)
        {
            _instantiator = instantiator;
            _windowConfigProvider = windowConfigProvider;
        }

        public void CreateUIRoot()
        {
            GameObject root = _instantiator.InstantiatePrefabResource(UI_ROOT_PATH);
            _uiRoot = root.transform;
        }

        public void CreateHubWindow()
        {
            WindowConfig config = _windowConfigProvider.GetConfig(WindowId.Hub);
            var window = _instantiator.InstantiatePrefabForComponent<HubWindow>(config.Prefab, _uiRoot);
        }
    }
}