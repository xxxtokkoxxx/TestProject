using System;
using System.Collections.Generic;
using Sdk.CodeBase.SdkStateMachine.States;

namespace Sdk.CodeBase.SdkStateMachine
{
    public class StateMachineInitializer : IStateMachineInitializer
    {
        private readonly IBootstrapState _bootstrap;
        private readonly IPlayModeState _playModeState;
        private readonly IStateMachine _stateMachine;

        public StateMachineInitializer(IBootstrapState bootstrap,
            IPlayModeState playModeState,
            IStateMachine stateMachine)
        {
            _bootstrap = bootstrap;
            _playModeState = playModeState;
            _stateMachine = stateMachine;
        }
        
        public void Initialize()
        {
            var states = new Dictionary<Type, IState>()
            {
                {typeof(BootstrapState), _bootstrap},
                {typeof(PlayModeState), _playModeState}
            };
            
            _stateMachine.SetStates(states);
        }
    }
}