namespace SDK.Sdk.CodeBase.Data.RunTime
{
    public interface IRuntimeDataContainer
    {
        Vast Vast { get; set; }
        PurchaseData PurchaseData { get; set; }
        PurchaseInfoDto PurchaseInfoDto { get; set; }
    }
}