using System;
using System.Linq;
using Sdk.CodeBase.Utilities;

namespace Sdk.CodeBase.UI.Factories
{
    public class ViewFactory : BaseFactory, IViewFactory
    {
        private BaseView[] _views;
        
        private readonly ISpawnPointProvider _spawnPointProvider;

        public ViewFactory(ISpawnPointProvider spawnPointProvider)
        {
            _spawnPointProvider = spawnPointProvider;
        }
        
        public void SetViews(BaseView[] views)
        {
            _views = views;
        }

        public TView CreateView<TView>(ViewType viewType) where TView : BaseView
        {
            var view = _views.FirstOrDefault(a => a.ViewType == viewType);

            if (view == null)
            {
                throw new NullReferenceException("There is no appropriate view");
            }

            var viewObject = Create(view, _spawnPointProvider.UiSpawnPoint);
            
            return viewObject.GetComponent<TView>();
        }
    }
}