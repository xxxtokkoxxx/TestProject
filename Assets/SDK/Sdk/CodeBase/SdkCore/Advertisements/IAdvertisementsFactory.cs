using SDK.Sdk.CodeBase.SdkCore.SdkDataWriter;

namespace SDK.Sdk.CodeBase.SdkCore.Advertisements
{
    public interface IAdvertisementsFactory
    {
        void SetPrefabs(MediaPlayer videoPlayer);
        MediaPlayer CreateVideoPlayer();
    }
}