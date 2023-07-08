using UnityEngine;

namespace MainModule
{
    public sealed class LoadingApplicationState : IState, IApplicationState
    {
        private readonly ApplicationStateMachine _applicationStateMachine;

        public LoadingApplicationState(ApplicationStateMachine applicationStateMachine)
        {
            _applicationStateMachine = applicationStateMachine;
        }
        
        public void Enter()
        {
            Debug.Log("Loading application");
            _applicationStateMachine.EnterToState<HubApplicationState>();
        }
    }
}