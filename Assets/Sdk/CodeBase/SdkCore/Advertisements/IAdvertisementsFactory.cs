using Sdk.CodeBase.SdkCore.SdkDataWriter;

namespace Sdk.CodeBase.SdkCore.Advertisements
{
    public interface IAdvertisementsFactory
    {
        void SetPrefabs(MediaPlayer videoPlayer);
        MediaPlayer CreateVideoPlayer();
    }
}