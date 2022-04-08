using System;
using System.Collections.Generic;

namespace SDK.Sdk.CodeBase.SdkStateMachine
{
    public interface IStateMachine
    {
        void SetStates(Dictionary<Type, IState> states);
        void Enter<TState>() where TState : class, IState;
    }
}