using System.Threading.Tasks;
using SDK.Sdk.CodeBase.Constants;
using SDK.Sdk.CodeBase.ResourcesManagement;
using SDK.Sdk.CodeBase.SdkCore.SdkDataWriter;
using UnityEngine;

namespace SDK.Sdk.CodeBase.SdkCore.Advertisements
{
    public class AdvertisementsLoadingOperation : ILoadingOperation
    {
        private readonly IAdvertisementsFactory _factory;

        public AdvertisementsLoadingOperation(IAdvertisementsFactory factory)
        {
            _factory = factory;
        }
        
        public async Task Load()
        {
            var playerPrefab = Resources.Load<MediaPlayer>(AssetsDataPath.Advertisements);
            
            _factory.SetPrefabs(playerPrefab);
            await Task.CompletedTask;
        }
    }
}