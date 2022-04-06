namespace Sdk.CodeBase.UI.Screens.Ads
{
    public class AdsScreenView : BaseView
    {
        private IAdsViewCallbacks _adsViewCallbacks;
        
        public override ViewType ViewType => ViewType.Ads;

        public void Initialize(IAdsViewCallbacks adsViewCallbacks)
        {
            _adsViewCallbacks = adsViewCallbacks;
        }
        
        public void OnShowVideoClick()
        {
            _adsViewCallbacks.OnShowVideoClick();
        }

        public void OnHideVideoClick()
        {
            _adsViewCallbacks.OnHideVideoClick();
        }
    }
}