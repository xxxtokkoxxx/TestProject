using System.Collections;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Sdk.CodeBase.Data.RunTime;
using Sdk.CodeBase.Network;
using Sdk.CodeBase.SdkCore.Advertisements;
using Sdk.CodeBase.SdkCore.SdkDataWriter;
using Sdk.CodeBase.UI.Factories;
using Sdk.CodeBase.Utilities;
using Object = UnityEngine.Object;

namespace Sdk.CodeBase.UI.Screens.Ads
{
    public class AdsScreenController : IViewController
    {
        private AdsScreenView _view;
        private MediaPlayer _mediaPlayer;
        private bool _isSubscribed;

        private readonly IViewFactory _viewFactory;
        private readonly INetworkService _networkService;
        private readonly IDataReadWriteService _dataReadWriteService;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly IAdvertisementsFactory _advertisementsFactory;
        
        private IAdsViewCallbacks _callbacks;

        public AdsScreenController(IViewFactory viewFactory,
            INetworkService networkService,
            IDataReadWriteService dataReadWriteService,
            ICoroutineRunner coroutineRunner,
            IRuntimeDataContainer runtimeDataContainer,
            IAdvertisementsFactory advertisementsFactory)
        {
            _viewFactory = viewFactory;
            _networkService = networkService;
            _dataReadWriteService = dataReadWriteService;
            _coroutineRunner = coroutineRunner;
            _advertisementsFactory = advertisementsFactory;
        }

        public ViewType ViewType => ViewType.Ads;

        public void Show()
        {
            CreateView();
            InitializeCallbacks();
            Subscribe();
            
            _view.Initialize(_callbacks);
        }

        public void Hide()
        {
            UnSubscribe();

            if (_view != null)
            {
                Object.Destroy(_view.gameObject);
            }
        }

        private void CreateView()
        {
            _view = _viewFactory.CreateView<AdsScreenView>(ViewType);
        }

        private void InitializeCallbacks()
        {
            _callbacks = new AdsViewCallbacks();
            
        }

        private void Subscribe()
        {
            if (_isSubscribed)
            {
                return;
            }
            
            _callbacks.OnShowVideoClicked += OnShowVideoClicked;
            _callbacks.OnHideVideoClicked += OnHideVideoClicked;
            
            _isSubscribed = true;
        }

        private void UnSubscribe()
        {
            _callbacks.OnShowVideoClicked -= OnShowVideoClicked;
            _callbacks.OnHideVideoClicked -= OnHideVideoClicked;

            _isSubscribed = false;
        }

        private void OnShowVideoClicked()
        {
            _coroutineRunner.RunCoroutine(LoadVastData());
        }

        private void OnHideVideoClicked()
        {
            if (_mediaPlayer != null)
            {
                Object.Destroy(_mediaPlayer.gameObject);
            }
        }

        private IEnumerator LoadVastData()
        {
            yield return _networkService.GetRequest(ApiCredentials.MainUrl + ApiCredentials.VideoAddUrl,
                OnVastDataLoaded);
        }

        private void OnVastDataLoaded(byte[] data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Vast));
            
            TextReader reader = new StreamReader(new MemoryStream(data), Encoding.Default);
            var vast = (Vast)serializer.Deserialize(reader);

            var medialUrl = vast.Ad.InLine.Creatives.Creative.Linear.MediaFiles.MediaFile;

            _coroutineRunner.RunCoroutine(_networkService.GetRequest(medialUrl, SaveVideoFile));
            PrepareAndPlayVideo(medialUrl);
        }

        private void PrepareAndPlayVideo(string mediaUrl)
        {
            if (_mediaPlayer == null)
            {
                _mediaPlayer = _advertisementsFactory.CreateVideoPlayer();
            }
            
            _mediaPlayer.PlayVideo(mediaUrl);
        }

        private void SaveVideoFile(byte[] data)
        {
            _dataReadWriteService.WriteData(data,"/video");
        }
    }
}