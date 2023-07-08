using UnityEngine;

namespace MainModule
{
    public sealed class WindowService : IWindowService
    {
        private const string TAG = nameof(WindowService) + ":";
        
        private readonly IUIFactory _uiFactory;

        public WindowService(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }
        
        public void OpenWindow(WindowId windowId)
        {
            switch (windowId)
            {
                case WindowId.Hub:
                    _uiFactory.CreateHubWindow();
                    break;
                default:
                    Debug.LogError($"{TAG} Unknown window id '{windowId}'");
                    break;
            }
        }
    }
}