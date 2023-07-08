using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MainModule
{
    public sealed class Bootstrapper : MonoBehaviour
    {
        private ApplicationStateMachine _applicationStateMachine;

        [Inject]
        public void Construct(ApplicationStateMachine applicationStateMachine, List<IApplicationState> applicationStates) 
        {
            _applicationStateMachine = applicationStateMachine;

            _applicationStateMachine.AddStates(applicationStates);
        }

        public void Awake()
        {
            _applicationStateMachine.EnterToState<LoadingApplicationState>();
        }
    }
}