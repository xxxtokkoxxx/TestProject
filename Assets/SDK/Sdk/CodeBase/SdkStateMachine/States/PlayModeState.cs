using SDK.Sdk.CodeBase.UI;
using UnityEngine.SceneManagement;

namespace SDK.Sdk.CodeBase.SdkStateMachine.States
{
    public class PlayModeState : IPlayModeState
    {
        private const string AdsSampleScene = "AdsSample";
        private const string PurchaseSampleScene = "PurchaseSample";

        private readonly IScreenService _screenService;

        public PlayModeState(IScreenService screenService)
        {
            _screenService = screenService;
        }

        public void Enter()
        {
            OpenSampleScenesView(SceneManager.GetActiveScene().name);
        }

        public void Exit()
        {
            
        }

        private void OpenSampleScenesView(string sceneName)
        {
            switch (sceneName)
            {
                case AdsSampleScene:
                    _screenService.ShowScreen(ViewType.Ads);
                    break;
                case PurchaseSampleScene:
                    _screenService.ShowScreen(ViewType.Purchase);
                    break;
            }
        }
    }
}