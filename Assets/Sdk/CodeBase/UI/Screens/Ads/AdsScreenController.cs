using System.Collections;
using Sdk.CodeBase.Network;
using Sdk.CodeBase.SdkCore.SdkDataWriter;
using Sdk.CodeBase.UI.Factories;
using Sdk.CodeBase.Utilities;
using UnityEngine;

namespace Sdk.CodeBase.UI.Screens.Ads
{
    public class AdsScreenController : IViewController
    {
        private readonly IViewFactory _viewFactory;
        private readonly INetworkService _networkService;
        private readonly IDataReaderService _dataReaderService;
        private readonly ICoroutineRunner _coroutineRunner;

        private IAdsViewCallbacks _callbacks;
        public ViewType ViewType => ViewType.Ads;

        private bool _isSubscribed;
        private AdsScreenView _view;

        public AdsScreenController(IViewFactory viewFactory,
            INetworkService networkService,
            IDataReaderService dataReaderService,
            ICoroutineRunner coroutineRunner)
        {
            _viewFactory = viewFactory;
            _networkService = networkService;
            _dataReaderService = dataReaderService;
            _coroutineRunner = coroutineRunner;
        }
        
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
            _coroutineRunner.RunCoroutine(LoadVideo());
        }

        private void OnHideVideoClicked()
        {
            
        }

        private IEnumerator LoadVideo()
        {
            yield return _networkService.GetRequest(ApiCredentials.MainUrl + ApiCredentials.VideoAddUrl,
                OnVideoLoaded);
        }

        private void OnVideoLoaded(byte[] data)
        {
            // _dataReaderService.WriteData(data);
        }
    }
}