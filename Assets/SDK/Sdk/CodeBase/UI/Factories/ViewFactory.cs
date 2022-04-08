using System;
using System.Linq;
using SDK.Sdk.CodeBase.Utilities;
using Zenject;

namespace SDK.Sdk.CodeBase.UI.Factories
{
    public class ViewFactory : BaseFactory, IViewFactory
    {
        private BaseView[] _views;

        private readonly DiContainer _container;
        private readonly ISpawnPointProvider _spawnPointProvider;

        public ViewFactory(DiContainer container,
            ISpawnPointProvider spawnPointProvider)
        {
            _container = container;
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

            var viewObject = CreateWithDependencyInjection(_container, view, _spawnPointProvider.UiSpawnPoint);
            
            return viewObject.GetComponent<TView>();
        }
    }
}