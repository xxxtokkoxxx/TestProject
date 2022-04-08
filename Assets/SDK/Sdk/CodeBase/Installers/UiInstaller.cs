using SDK.Sdk.CodeBase.ResourcesManagement;
using SDK.Sdk.CodeBase.UI;
using SDK.Sdk.CodeBase.UI.Factories;
using SDK.Sdk.CodeBase.UI.Screens.Ads;
using SDK.Sdk.CodeBase.UI.Screens.Purchase;
using Zenject;

namespace SDK.Sdk.CodeBase.Installers
{
    public class UiInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindViewControllersInitializer();
            BindScreenService();
            BindViewFactory();
            BindAdsScreenController();
            BindPurchaseScreenController();
            BindViewsLoadingOperation();
        }

        private void BindViewControllersInitializer()
        {
            Container.Bind(typeof(ScreenServiceInitializer), typeof(IScreenServiceInitializer))
                .To<ScreenServiceInitializer>()
                .AsSingle();
        }

        private void BindScreenService()
        {
            Container.Bind(typeof(ScreenService), typeof(IScreenService))
                .To<ScreenService>()
                .AsSingle();
        }

        private void BindViewFactory()
        {
            Container.Bind(typeof(ViewFactory), typeof(IViewFactory))
                .To<ViewFactory>()
                .AsSingle();
        }

        private void BindAdsScreenController()
        {
            Container.Bind(typeof(AdsScreenController), typeof(IViewController))
                .To<AdsScreenController>()
                .AsSingle();
        }

        private void BindPurchaseScreenController()
        {
            Container.Bind(typeof(PurchaseScreenController), typeof(IViewController))
                .To<PurchaseScreenController>()
                .AsSingle();
        }

        private void BindViewsLoadingOperation()
        {
            Container.Bind(typeof(ViewLoadingOperation), typeof(ILoadingOperation))
                .To<ViewLoadingOperation>()
                .AsSingle();
        }
    }
}