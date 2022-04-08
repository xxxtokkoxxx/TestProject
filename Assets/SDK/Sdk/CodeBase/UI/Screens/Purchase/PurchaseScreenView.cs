using SDK.Sdk.CodeBase.Data.RunTime;
using UnityEngine;
using UnityEngine.UI;

namespace SDK.Sdk.CodeBase.UI.Screens.Purchase
{
    public class PurchaseScreenView : BaseView
    {
        [SerializeField] private GameObject _purchaseButtonSubView;
        [SerializeField] private PurchaseInfoSubView _purchaseInfoSubView;
        
        private IPurchaseViewCallbacks _callbacks;

        public override ViewType ViewType => ViewType.Purchase;

        public void Initialize(IPurchaseViewCallbacks callbacks)
        {
            _callbacks = callbacks;
        }

        public void SetPurchaseInfoSubViewEnabled(bool isEnabled)
        {
            _purchaseInfoSubView.gameObject.SetActive(isEnabled);
        }

        public void SetPurchaseButtonEnabled(bool isEnabled)
        {
            _purchaseButtonSubView.SetActive(isEnabled);
        }

        public void InitializePurchaseInfoSubView(PurchaseInfoDto data)
        {
            _purchaseInfoSubView.Initialize(data);
        }

        public void SetInfoTextEnabled(bool isEnabled, string infoText = null)
        {
            _purchaseInfoSubView.InfoText.text = infoText;
            _purchaseInfoSubView.InfoText.gameObject.SetActive(isEnabled);
        }

        public void OnShowPurchaseSubView()
        {
            _callbacks.OnShowPurchaseSubViewClick();
        }

        public void OnConfirmPurchaseClick()
        {
            _callbacks.OnConfirmPurchaseClick();
        }
        
        public void OnCloseButtonClicked()
        {
            _callbacks.OnCloseButtonClick();
        }

        public InputField[] GetInputFields() =>
            _purchaseInfoSubView.InputFields;
    }
}