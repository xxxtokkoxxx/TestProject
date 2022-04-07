using System;

namespace Sdk.CodeBase.UI.Screens.Purchase
{
    public class PurchaseViewCallbacks : IPurchaseViewCallbacks
    {
        public event Action OnPurchaseClicked;
        public event Action OnShowPurchaseViewClicked;
        public event Action OnCloseButtonClicked;

        public void OnPurchaseClick()
        {
            OnPurchaseClicked?.Invoke();
        }

        public void OnShowPurchaseViewClick()
        {
            OnShowPurchaseViewClicked?.Invoke();
        }

        public void OnCloseButtonClick()
        {
            OnCloseButtonClicked?.Invoke();
        }
    }
}