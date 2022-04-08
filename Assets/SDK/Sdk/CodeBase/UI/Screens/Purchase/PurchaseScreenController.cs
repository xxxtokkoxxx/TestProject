using System;
using System.Collections;
using Newtonsoft.Json;
using SDK.Sdk.CodeBase.Data.RunTime;
using SDK.Sdk.CodeBase.Network;
using SDK.Sdk.CodeBase.UI.Factories;
using SDK.Sdk.CodeBase.Utilities;
using SDK.Sdk.Extensions;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SDK.Sdk.CodeBase.UI.Screens.Purchase
{
    public class PurchaseScreenController : IViewController
    {
        private bool _isSubscribed;
        private bool _isCoroutineRan;
        private float _coroutineDuration = 1f;
        
        private string _jsonObject = "PurchaseInfo";
        private string _successPurchaseText = "Success";
        private string _errorPurchaseText = "Error: input fields are empty, please, fill in all fields";
        private string _purchaseInfoText = "Fill in all fields";
        
        private PurchaseScreenView _view;

        private IPurchaseViewCallbacks _callbacks;

        private readonly IViewFactory _viewFactory;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly INetworkService _networkService;
        private readonly IRuntimeDataContainer _runtimeDataContainer;
        private readonly IScreenService _screenService;
        private readonly ISpawnPointProvider _spawnPointProvider;

        public ViewType ViewType => ViewType.Purchase;

        public PurchaseScreenController(IViewFactory viewFactory,
            ICoroutineRunner coroutineRunner,
            INetworkService networkService,
            IRuntimeDataContainer runtimeDataContainer,
            IScreenService screenService)
        {
            _viewFactory = viewFactory;
            _coroutineRunner = coroutineRunner;
            _networkService = networkService;
            _runtimeDataContainer = runtimeDataContainer;
            _screenService = screenService;
        }
        
        public void Show()
        {
            InitializeCallbacks();
            Subscribe();

            _view = _viewFactory.CreateView<PurchaseScreenView>(ViewType.Purchase);
            _view.Initialize(_callbacks);

            ShowPurchaseButtonSubView();
        }

        public void Hide()
        {
            UnSubscribe();
            
            if (_view != null)
            {
                Object.Destroy(_view.gameObject);
            }
        }

        private void InitializeCallbacks()
        {
            _callbacks = new PurchaseViewCallbacks();
        }

        private void Subscribe()
        {
            if (_isSubscribed)
            {
                return;
            }
            
            _callbacks.OnConfirmPurchaseClicked += OnConfirmPurchaseClicked;
            _callbacks.OnShowPurchaseSubViewClicked += OnShowPurchaseSubViewClicked;
            _callbacks.OnCloseButtonClicked += OnCloseButtonClicked;
            
            _isSubscribed = true;
        }

        private void UnSubscribe()
        {
            _callbacks.OnConfirmPurchaseClicked -= OnConfirmPurchaseClicked;
            _callbacks.OnShowPurchaseSubViewClicked -= OnShowPurchaseSubViewClicked;
            _callbacks.OnCloseButtonClicked -= OnCloseButtonClicked;

            _isSubscribed = false;
        }

        private void OnCloseButtonClicked()
        {
            ShowPurchaseButtonSubView();
        }

        private void OnConfirmPurchaseClicked()
        {
            if (CheckIfInputFieldsNotEmpty())
            {
                _coroutineRunner.RunCoroutine(ShowSuccessPurchaseAnimation());
            }
            else
            {
                _view.SetInfoTextEnabled(true, _errorPurchaseText);
            }
        }

        private void OnShowPurchaseSubViewClicked()
        {
            _view.SetPurchaseInfoSubViewEnabled(true);
            _view.SetPurchaseButtonEnabled(false);

            GetPurchaseInfoData();
        }

        private void GetPurchaseInfoData()
        {
            var json = new PurchaseData();
            var jsonString = JsonConvert.SerializeObject(json);

            _coroutineRunner.RunCoroutine((_networkService.PostRequest(ApiCredentials.MainUrl + ApiCredentials.PurchaseUrl, 
                jsonString, SetReturnedData)));
        }
        
        private void SetReturnedData(string data)
        {
            var jsonString = data.GetModifiedJson(_jsonObject);
            var purchaseData = JsonConvert.DeserializeObject<PurchaseData>(jsonString);

            if (purchaseData == null)
            {
                Debug.LogError("purchase data is empty");
                return;
            }
            
            _runtimeDataContainer.PurchaseInfoDto = new PurchaseInfoDto(purchaseData.PurchaseInfo);
            ShowPurchaseInfoSubView(_runtimeDataContainer.PurchaseInfoDto);
        }

        private IEnumerator ShowSuccessPurchaseAnimation()
        {
            if (_isCoroutineRan)
            {
                yield break;
            }

            _isCoroutineRan = true;
            _view.SetInfoTextEnabled(true, _successPurchaseText);
            
            yield return new WaitForSeconds(_coroutineDuration);

            ShowPurchaseButtonSubView();
            _isCoroutineRan = false;
        }

        private bool CheckIfInputFieldsNotEmpty()
        {
            foreach (var field in _view.GetInputFields())
            {
                if (string.IsNullOrEmpty(field.text))
                {
                    return false;
                }
            }

            return true;
        }

        private void ShowPurchaseButtonSubView()
        {
            _view.SetPurchaseInfoSubViewEnabled(false);
            _view.SetPurchaseButtonEnabled(true);
            
            _view.SetInfoTextEnabled(true, _purchaseInfoText);

            foreach (var field in _view.GetInputFields())
            {
                field.text = String.Empty;
            }
        }

        private void ShowPurchaseInfoSubView(PurchaseInfoDto data)
        {
            _view.InitializePurchaseInfoSubView(data);
        }
    }
}