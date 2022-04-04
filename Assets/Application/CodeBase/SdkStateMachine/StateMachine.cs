using System;
using System.Collections.Generic;

namespace Application.CodeBase.SdkStateMachine
{
    public class StateMachine : IStateMachine
    {
        private Dictionary<Type, IState> _states;
        
        private IState _activeState;

        public void SetStates(Dictionary<Type, IState> states)
        {
            _states = states;
        }

        public void Enter<TState>() where TState : class, IState
        {
            if (_activeState != null)
            {
                _activeState.Exit();
            }

            _activeState = GetState<TState>();
            _activeState.Enter();
        }

        private TState GetState<TState>() where TState : class, IState
        {
            return _states[typeof(TState)] as TState;
        }
    }
}