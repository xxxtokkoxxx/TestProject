using System;

namespace Sdk.CodeBase.UI.Screens.Purchase
{
    public interface IPurchaseViewCallbacks
    {
        event Action OnPurchaseClicked;
        event Action OnShowPurchaseViewClicked;
        event Action OnCloseButtonClicked;
        void OnPurchaseClick();
        void OnShowPurchaseViewClick();
        void OnCloseButtonClick();
    }
}