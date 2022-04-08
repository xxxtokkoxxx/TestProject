using System;

namespace SDK.Sdk.CodeBase.UI.Screens.Ads
{
    public class AdsViewCallbacks : IAdsViewCallbacks
    {
        public event Action OnShowVideoClicked;
        public event Action OnHideVideoClicked;

        public void OnShowVideoClick()
        {
            OnShowVideoClicked?.Invoke();
        }
        
        public void OnHideVideoClick()
        {
            OnHideVideoClicked?.Invoke();
        }
    }
}