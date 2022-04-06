using UnityEngine;
using UnityEngine.Video;

namespace Sdk.CodeBase.SdkCore.SdkDataWriter
{
    public class MediaPlayer : MonoBehaviour
    {
        [SerializeField] private VideoPlayer _videoPlayer;

        public void PlayVideo(string url)
        {
            _videoPlayer.url = url;
            _videoPlayer.Prepare();
            _videoPlayer.prepareCompleted += OnVideoPrepared;
        }

        private void OnVideoPrepared(VideoPlayer videoPlayer)
        {
            videoPlayer.prepareCompleted -= OnVideoPrepared;
            videoPlayer.Play();
        }
    }
}