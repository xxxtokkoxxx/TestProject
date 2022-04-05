namespace Sdk.CodeBase.UI.Factories
{
    public interface IViewFactory : IFactory
    {
        void SetViews(BaseView[] views);
        BaseView CreateView(ViewType viewType);
    }
}