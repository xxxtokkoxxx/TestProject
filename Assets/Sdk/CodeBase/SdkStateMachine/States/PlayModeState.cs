using Sdk.CodeBase.UI;

namespace Sdk.CodeBase.SdkStateMachine.States
{
    public class PlayModeState : IPlayModeState
    {
        private readonly IScreenService _screenService;

        public PlayModeState(IScreenService screenService)
        {
            _screenService = screenService;
        }
        
        public void Enter()
        {
            _screenService.ShowScreen(ViewType.Purchase);
        }

        public void Exit()
        {
        }
    }
}