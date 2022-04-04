namespace Application.CodeBase.SdkStateMachine
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
}