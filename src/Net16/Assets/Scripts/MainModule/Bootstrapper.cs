using UnityEngine;
using Zenject;

namespace MainModule
{
    public sealed class Bootstrapper : MonoBehaviour
    {
        private ApplicationStateMachine _applicationStateMachine;

        [Inject]
        public void Construct(ApplicationStateMachine applicationStateMachine, HackingApplicationState hackingApplicationState)
        {
            _applicationStateMachine = applicationStateMachine;

            _applicationStateMachine.AddState(hackingApplicationState);
        }

        public void Awake()
        {
            _applicationStateMachine.EnterToState<HackingApplicationState>();
        }
    }
}