using Sdk.CodeBase.SdkCore.Advertisements;
using Sdk.CodeBase.UI;

namespace Sdk.CodeBase.SdkCore
{
    public class Sdk : ISdk
    {
        private readonly IAdvertisementPreparer _adsPreparer;
        private readonly IScreenService _screenService;

        public Sdk(IAdvertisementPreparer adsPreparer, 
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