using System.Collections;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Sdk.CodeBase.Messenger;
using Sdk.CodeBase.SdkCore;
using Sdk.CodeBase.SdkCore.Advertisements;
using Sdk.CodeBase.SdkCore.SdkDataWriter;
using Sdk.CodeBase.UI.Factories;
using Object = UnityEngine.Object;

namespace Sdk.CodeBase.UI.Screens.Ads
{
    public class AdsScreenController : IViewController, IListener
    {
        private AdsScreenView _view;
        private MediaPlayer _mediaPlayer;
        private bool _isSubscribed;
        private string _videoId = "/video";

        private readonly IViewFactory _viewFactory;
        private readonly IDataReadWriteService _dataReadWriteService;
        private readonly ISdk _sdk;
        private readonly IMessengerService _messengerService;

        private IAdsViewCallbacks _callbacks;

        public AdsScreenController(IViewFactory viewFactory,
            IDataReadWriteService dataReadWriteService,
            ISdk sdk,
            IMessengerService messengerService)
        {
            _viewFactory = viewFactory;
            _dataReadWriteService = dataReadWriteService;
            _sdk = sdk;
            _messengerService = messengerService;
        }

        public ViewType ViewType => ViewType.Ads;

        public void Receive(IMessage message)
        {
            switch (message)
            {
                case AdsDataLoadedMessage msg:
                    SaveVideoFile(msg.Data);
                    break;
            }
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
            _messengerService.Register(this);
            
            _isSubscribed = true;
        }

        private void UnSubscribe()
        {
            _callbacks.OnShowVideoClicked -= OnShowVideoClicked;
            _callbacks.OnHideVideoClicked -= OnHideVideoClicked;
            _messengerService.UnRegister(this);

            _isSubscribed = false;
        }

        private void OnShowVideoClicked()
        {
            _sdk.ShowVideoAdvertisement();
        }

        private void OnHideVideoClicked()
        {
            _sdk.HideVideoAdvertisement();
        }

        private void SaveVideoFile(byte[] data)
        {
            _dataReadWriteService.WriteData(data, _videoId);
        }
    }
}