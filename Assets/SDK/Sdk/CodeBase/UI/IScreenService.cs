namespace SDK.Sdk.CodeBase.UI
{
    public interface IScreenService
    {
        void SetControllers(IViewController[] views);
        void ShowScreen(ViewType viewType);
        void HideScreen(ViewType viewType);
    }
}