using Sdk.CodeBase.Data.RunTime;
using Sdk.CodeBase.Messenger;
using Sdk.CodeBase.Network;
using Sdk.CodeBase.ResourcesManagement;
using Sdk.CodeBase.SdkCore;
using Sdk.CodeBase.SdkCore.Advertisements;
using Sdk.CodeBase.SdkCore.SdkDataWriter;
using Zenject;

namespace Sdk.CodeBase.Installers
{
    public class SdkCore : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindStateMachineInitializer();
            BindNetworkService();
            BindRunTimeData();
            BindMediaPlayerLoadingOperation();
            BindAdvertisementsFactory();
            BindSdk();
            BindMessengerService();
            BindAdsPreparer();
        }

        private void BindStateMachineInitializer()
        {
            Container.Bind(typeof(DataReadWriteService), typeof(IDataReadWriteService))
                .To<DataReadWriteService>()
                .AsSingle();
        }

        private void BindRunTimeData()
        {
            Container.Bind(typeof(RunTimeDataContainer), typeof(IRuntimeDataContainer))
                .To<RunTimeDataContainer>()
                .AsSingle();
        }

        private void BindNetworkService()
        {
            Container.Bind(typeof(NetworkService), typeof(INetworkService))
                .To<NetworkService>()
                .AsSingle();
        }

        private void BindMediaPlayerLoadingOperation()
        {
            Container.Bind(typeof(AdvertisementsLoadingOperation), typeof(ILoadingOperation))
                .To<AdvertisementsLoadingOperation>()
                .AsSingle();
        }

        private void BindAdvertisementsFactory()
        {
            Container.Bind(typeof(AdvertisementFactory), typeof(IAdvertisementsFactory))
                .To<AdvertisementFactory>()
                .AsSingle();
        }

        private void BindSdk()
        {
            Container.Bind(typeof(CodeBase.SdkCore.Sdk), typeof(ISdk))
                .To<CodeBase.SdkCore.Sdk>()
                .AsSingle();
        }
        
        private void BindMessengerService()
        {
            Container.Bind(typeof(MessengerService), typeof(IMessengerService))
                .To<MessengerService>()
                .AsSingle();
        }
        
        private void BindAdsPreparer()
        {
            Container.Bind(typeof(AdvertisementPreparer), typeof(IAdvertisementPreparer))
                .To<AdvertisementPreparer>()
                .AsSingle();
        }
    }
}