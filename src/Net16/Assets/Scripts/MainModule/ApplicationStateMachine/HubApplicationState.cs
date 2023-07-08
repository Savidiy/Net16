using UnityEngine;

namespace MainModule
{
    public sealed class HubApplicationState : IState, IApplicationState
    {
        private readonly IWindowService _windowService;

        public HubApplicationState(IWindowService windowService)
        {
            _windowService = windowService;
        }
        
        public void Enter()
        {
            Debug.Log("Enter to Hub");
            _windowService.OpenWindow(WindowId.Hub);
        }
    }
}