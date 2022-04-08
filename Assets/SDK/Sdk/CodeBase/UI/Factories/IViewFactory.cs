namespace SDK.Sdk.CodeBase.UI.Factories
{
    public interface IViewFactory : IFactory
    {
        void SetViews(BaseView[] views);
        TView CreateView<TView>(ViewType viewType) where TView : BaseView;
    }
}