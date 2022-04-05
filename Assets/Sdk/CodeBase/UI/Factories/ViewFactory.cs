using System.Linq;

namespace Sdk.CodeBase.UI.Factories
{
    public class ViewFactory : BaseFactory, IViewFactory
    {
        private BaseView[] _views;
        
        public void SetViews(BaseView[] views)
        {
            _views = views;
        }
        
        public BaseView CreateView(ViewType viewType)
        {
            var view = _views.FirstOrDefault(a => a.ViewType == viewType);

            if (view == null)
            {
                return null;
            }

            return view;
        }
    }
}