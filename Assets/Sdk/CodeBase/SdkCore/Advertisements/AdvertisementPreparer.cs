using System.Collections;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Sdk.CodeBase.Data.RunTime;
using Sdk.CodeBase.Messenger;
using Sdk.CodeBase.Network;
using Sdk.CodeBase.SdkCore.SdkDataWriter;
using Sdk.CodeBase.Utilities;
using UnityEngine;

namespace Sdk.CodeBase.SdkCore.Advertisements
{
    public class AdvertisementPreparer : IAdvertisementPreparer
    {
        private readonly INetworkService _networkService;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IMessengerService _messengerService;
        private readonly IAdvertisementsFactory _advertisementsFactory;

        private MediaPlayer _mediaPlayer;

        public AdvertisementPreparer(INetworkService networkService, 
            ICoroutineRunner coroutineRunner,
            IMessengerService messengerService,
            IAdvertisementsFactory advertisementsFactory)
        {
            _networkService = networkService;
            _coroutineRunner = coroutineRunner;
            _messengerService = messengerService;
            _advertisementsFactory = advertisementsFactory;
        }

        public void ShowVideoAdvertisement()
        {
            _coroutineRunner.RunCoroutine(LoadAdsData());
        }

        public void HideVideoAdvertisement()
        {
            if (_mediaPlayer != null)
            {
                Object.Destroy(_mediaPlayer.gameObject);
            }
        }
        
        private IEnumerator LoadAdsData()
        {
            yield return _networkService.GetRequest(ApiCredentials.MainUrl + ApiCredentials.VideoAddUrl, OnAdsDataLoaded);
        }

        private void OnAdsDataLoaded(byte[] data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Vast));
            
            TextReader reader = new StreamReader(new MemoryStream(data), Encoding.Default);
            var vast = (Vast)serializer.Deserialize(reader);

            var medialUrl = vast.Ad.InLine.Creatives.Creative.Linear.MediaFiles.MediaFile;
            PrepareAndPlayVideo(medialUrl);
            
            _messengerService.Send(new AdsDataLoadedMessage(data));
        }
        
        private void PrepareAndPlayVideo(string mediaUrl)
        {
            if (_mediaPlayer == null)
            {
                _mediaPlayer = _advertisementsFactory.CreateVideoPlayer();
            }
            
            _mediaPlayer.PlayVideo(mediaUrl);
        }
    }
}