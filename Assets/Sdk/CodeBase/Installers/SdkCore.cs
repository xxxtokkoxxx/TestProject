using Sdk.CodeBase.Network;
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
        }

        private void BindStateMachineInitializer()
        {
            Container.Bind(typeof(DataReaderService), typeof(IDataReaderService))
                .To<DataReaderService>()
                .AsSingle();
        }
        
        private void BindNetworkService()
        {
            Container.Bind(typeof(NetworkService), typeof(INetworkService))
                .To<NetworkService>()
                .AsSingle();
        }
    }
}