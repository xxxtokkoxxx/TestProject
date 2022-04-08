using System;

namespace SDK.Sdk.CodeBase.UI.Screens.Purchase
{
    public interface IPurchaseViewCallbacks
    {
        event Action OnConfirmPurchaseClicked;
        event Action OnShowPurchaseSubViewClicked;
        event Action OnCloseButtonClicked;
        void OnConfirmPurchaseClick();
        void OnShowPurchaseSubViewClick();
        void OnCloseButtonClick();
    }
}