using System;

namespace SDK.Sdk.CodeBase.UI.Screens.Ads
{
    public interface IAdsViewCallbacks
    {
        event Action OnShowVideoClicked;
        event Action OnHideVideoClicked;
        void OnShowVideoClick();
        void OnHideVideoClick();
    }
}