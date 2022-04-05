namespace Sdk.CodeBase.SdkStateMachine
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
}