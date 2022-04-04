using Application.CodeBase.SdkStateMachine;
using Application.CodeBase.SdkStateMachine.States;
using UnityEngine;
using Zenject;

namespace Application.CodeBase
{
    public class SdkBootstrapper : MonoBehaviour
    {
        private IStateMachineInitializer _stateMachineInitializer;
        private IStateMachine _stateMachine;

        [Inject]
        public void Construct(IStateMachineInitializer stateMachineInitializer,
            IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _stateMachineInitializer = stateMachineInitializer;
        }

        private void Start()
        {
            _stateMachineInitializer.Initialize();
            _stateMachine.Enter<BootstrapState>();
        }
    }
}
