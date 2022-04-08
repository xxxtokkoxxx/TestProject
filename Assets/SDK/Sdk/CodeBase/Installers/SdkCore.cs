using SDK.Sdk.CodeBase.Data.RunTime;
using SDK.Sdk.CodeBase.Messenger;
using SDK.Sdk.CodeBase.Network;
using SDK.Sdk.CodeBase.ResourcesManagement;
using SDK.Sdk.CodeBase.SdkCore.Advertisements;
using SDK.Sdk.CodeBase.SdkCore.SdkDataWriter;
using Zenject;

namespace SDK.Sdk.CodeBase.Installers
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