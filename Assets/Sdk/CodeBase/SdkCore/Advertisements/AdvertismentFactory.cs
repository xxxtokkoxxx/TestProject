using Sdk.CodeBase.SdkCore.SdkDataWriter;

namespace Sdk.CodeBase.SdkCore.Advertisements
{
    public class AdvertisementFactory : BaseFactory, IAdvertisementsFactory
    {
        private MediaPlayer _videoPlayer;
        
        public void SetPrefabs(MediaPlayer videoPlayer)
        {
            _videoPlayer = videoPlayer;
        }

        public MediaPlayer CreateVideoPlayer()
        {
            var videoPlayer = Create(_videoPlayer);
            return videoPlayer;
        }
    }

    public interface IAdvertisementPreparer
    {
        void ShowVideoAdvertisement();
        void HideVideoAdvertisement();
    }
}