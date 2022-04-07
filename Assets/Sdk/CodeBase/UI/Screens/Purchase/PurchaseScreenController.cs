using Sdk.CodeBase.UI.Factories;
using Sdk.CodeBase.Utilities;
using UnityEngine;

namespace Sdk.CodeBase.UI.Screens.Purchase
{
    public class PurchaseScreenController : IViewController
    {
        private bool _isSubscribed;
        private PurchaseScreenView _view;

        private IPurchaseViewCallbacks _callbacks;
        
        private readonly IViewFactory _viewFactory;
        private readonly ISpawnPointProvider _spawnPointProvider;

        public ViewType ViewType => ViewType.Purchase;

        public PurchaseScreenController(IViewFactory viewFactory)
        {
            _viewFactory = viewFactory;
        }
        
        public void Show()
        {
            InitializeCallbacks();
            Subscribe();

            _view = _viewFactory.CreateView<PurchaseScreenView>(ViewType.Purchase);
        }

        public void Hide()
        {
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
            
            _callbacks.OnPurchaseClicked += OnPurchaseClicked;
            _callbacks.OnShowPurchaseViewClicked += OnShowPurchaseViewClicked;
            _callbacks.OnCloseButtonClicked += OnCloseButtonClicked;
            
            _isSubscribed = true;
        }

        private void UnSubscribe()
        {
            _callbacks.OnPurchaseClicked -= OnPurchaseClicked;
            _callbacks.OnShowPurchaseViewClicked -= OnShowPurchaseViewClicked;
            _callbacks.OnCloseButtonClicked -= OnCloseButtonClicked;

            _isSubscribed = false;
        }

        private void OnCloseButtonClicked()
        {
            
        }

        private void OnShowPurchaseViewClicked()
        {
            
        }

        private void OnPurchaseClicked()
        {
            
        }
    }
}