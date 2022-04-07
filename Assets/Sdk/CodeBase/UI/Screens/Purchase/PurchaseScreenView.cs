using UnityEngine;

namespace Sdk.CodeBase.UI.Screens.Purchase
{
    public class PurchaseScreenView : BaseView
    {
        [SerializeField] private GameObject _purchaseInfoPanel;

        private IPurchaseViewCallbacks _callbacks;
        
        public override ViewType ViewType => ViewType.Purchase;

        public void Initialize(IPurchaseViewCallbacks callbacks)
        {
            _callbacks = callbacks;
        }
        
        public void SetPurchaseInfoPanelEnabled(bool isEnabled)
        {
            _purchaseInfoPanel.SetActive(isEnabled);
        }

        public void OnPurchaseClicked()
        {
            _callbacks.OnPurchaseClick();
        }
        
        public void OnShowPurchaseViewClicked()
        {
            _callbacks.OnShowPurchaseViewClick();
        }

        public void OnCloseButtonClicked()
        {
            _callbacks.OnCloseButtonClick();
        }
    }
}