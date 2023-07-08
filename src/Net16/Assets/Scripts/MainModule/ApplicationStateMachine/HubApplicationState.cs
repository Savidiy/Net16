using UnityEngine;

namespace MainModule
{
    public sealed class HubApplicationState : IState, IApplicationState
    {
        public HubApplicationState()
        {
        }
        
        public void Enter()
        {
            Debug.Log("Enter to Hub");
        }
    }
}