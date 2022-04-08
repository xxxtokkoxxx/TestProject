using SDK.Sdk.CodeBase.SdkCore.Advertisements;
using SDK.Sdk.CodeBase.UI;
using SDK.Sdk.CodeBase.Utilities;
using Zenject;

namespace SDK.Sdk.CodeBase.SdkCore
{
    public class Sdk : Singleton<Sdk>
    {
        private IAdvertisementPreparer _adsPreparer;
        private IScreenService _screenService;

        [Inject]
        public void Construct(IAdvertisementPreparer adsPreparer, 
            IScreenService screenService)
        {
            _adsPreparer = adsPreparer;
            _screenService = screenService;
        }
        
        public void ShowVideoAdvertisement()
        {
            _adsPreparer.ShowVideoAdvertisement();
        }
        
        public void HideVideoAdvertisement()
        {
            _adsPreparer.HideVideoAdvertisement();
        }

        public void ShowPurchase()
        {
            _screenService.ShowScreen(ViewType.Purchase);
        }

        public void HidePurchase()
        {
            _screenService.HideScreen(ViewType.Purchase);
        }
    }
}