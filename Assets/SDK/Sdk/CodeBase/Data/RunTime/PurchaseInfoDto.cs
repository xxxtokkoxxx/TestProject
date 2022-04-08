namespace SDK.Sdk.CodeBase.Data.RunTime
{
    public class PurchaseInfoDto
    {
        public string Title { get; }
        public string ItemImage { get; }
        public string Currency { get; }
        public string CurrencySign { get; }

        public PurchaseInfoDto(PurchaseInfo info)
        {
            Title = info.Title;
            ItemImage = info.ItemImage;
            Currency = info.Currency;
            CurrencySign = info.CurrencySign;
        } 
    }
}