using UnityEngine;

namespace Application.CodeBase.SdkStateMachine.States
{
    public class BootstrapState : IBootstrapState
    {
        public void Enter()
        {
            Debug.Log("enter bootstrap");
        }

        public void Exit()
        {
            
        }
    }
}