using System.Threading.Tasks;
using Sdk.CodeBase.Constants;
using Sdk.CodeBase.ResourcesManagement;
using Sdk.CodeBase.SdkCore.SdkDataWriter;
using UnityEngine;

namespace Sdk.CodeBase.SdkCore.Advertisements
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