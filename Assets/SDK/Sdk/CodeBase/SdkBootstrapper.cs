using SDK.Sdk.CodeBase.SdkStateMachine;
using SDK.Sdk.CodeBase.SdkStateMachine.States;
using UnityEngine;
using Zenject;

namespace SDK.Sdk.CodeBase
{
    public class SdkBootstrapper : MonoBehaviour
    {
        private IStateMachine _stateMachine;
        private IStateMachineInitializer _stateMachineInitializer;

        [Inject]
        public void Construct(IStateMachineInitializer stateMachineInitializer,
            IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _stateMachineInitializer = stateMachineInitializer;
        }

        private void Start()
        {
            DontDestroyOnLoad(this);
            
            _stateMachineInitializer.Initialize();
            _stateMachine.Enter<BootstrapState>();
        }
    }
}