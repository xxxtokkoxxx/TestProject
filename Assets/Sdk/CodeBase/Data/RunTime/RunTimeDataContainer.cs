namespace Sdk.CodeBase.Data.RunTime
{
    public class RunTimeDataContainer : IRuntimeDataContainer
    {
        public Vast Vast { get; set; }
        public PurchaseData PurchaseData { get; set; }
        public PurchaseInfoDto PurchaseInfoDto { get; set; }
    }
}