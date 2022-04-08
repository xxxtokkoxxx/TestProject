using UnityEngine;
using UnityEngine.Video;

namespace Sdk.CodeBase.SdkCore.SdkDataWriter
{
    public class MediaPlayer : MonoBehaviour
    {
        [SerializeField] private VideoPlayer _videoPlayer;
        [SerializeField] private GameObject _mesh;

        public void PlayVideo(string url)
        {
            _videoPlayer.url = url;
            _mesh.SetActive(false);
            _videoPlayer.prepareCompleted += OnVideoPrepared;
            _videoPlayer.Prepare();
        }

        private void OnVideoPrepared(VideoPlayer videoPlayer)
        {
            _mesh.gameObject.SetActive(true);
            videoPlayer.prepareCompleted -= OnVideoPrepared;
            videoPlayer.Play();
        }
    }
}