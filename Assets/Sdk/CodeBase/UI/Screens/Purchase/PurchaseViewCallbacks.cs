using System;

namespace Sdk.CodeBase.UI.Screens.Purchase
{
    public class PurchaseViewCallbacks : IPurchaseViewCallbacks
    {
        public event Action OnConfirmPurchaseClicked;
        public event Action OnShowPurchaseSubViewClicked;
        public event Action OnCloseButtonClicked;

        public void OnConfirmPurchaseClick()
        {
            OnConfirmPurchaseClicked?.Invoke();
        }

        public void OnShowPurchaseSubViewClick()
        {
            OnShowPurchaseSubViewClicked?.Invoke();
        }

        public void OnCloseButtonClick()
        {
            OnCloseButtonClicked?.Invoke();
        }
    }
}