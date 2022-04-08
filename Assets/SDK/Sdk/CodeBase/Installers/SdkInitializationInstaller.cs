using SDK.Sdk.CodeBase.SdkStateMachine;
using SDK.Sdk.CodeBase.SdkStateMachine.States;
using Zenject;

namespace SDK.Sdk.CodeBase.Installers
{
    public class SdkInitializationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindStateMachineInitializer();
            BindStateMachine();
            BindBootStrapState();
            BindPlayModeState();
        }

        private void BindStateMachineInitializer()
        {
            Container.Bind(typeof(StateMachineInitializer), typeof(IStateMachineInitializer))
                .To<StateMachineInitializer>()
                .AsSingle();
        }

        private void BindStateMachine()
        {
            Container.Bind(typeof(StateMachine), typeof(IStateMachine))
                .To<StateMachine>()
                .AsSingle();
        }
        
        private void BindBootStrapState()
        {
            Container.Bind(typeof(BootstrapState), typeof(IBootstrapState))
                .To<BootstrapState>()
                .AsSingle();
        }
        
        private void BindPlayModeState()
        {
            Container.Bind(typeof(PlayModeState), typeof(IPlayModeState))
                .To<PlayModeState>()
                .AsSingle();
        }
    }
}