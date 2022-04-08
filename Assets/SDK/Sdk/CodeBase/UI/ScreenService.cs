using System;
using System.Linq;

namespace SDK.Sdk.CodeBase.UI
{
    public class ScreenService : IScreenService
    {
        private IViewController[] _views;
        private IViewController _previousViewController;

        public void SetControllers(IViewController[] views)
        {
            _views = views;
        }
        
        public void ShowScreen(ViewType viewType)
        {
            if (_previousViewController != null)
            {
                _previousViewController.Hide();
            }

            var viewController = GetViewController(viewType);
            viewController.Show();
            
            _previousViewController = viewController;
        }

        public void HideScreen(ViewType viewType)
        {
            var viewController = GetViewController(viewType);
            viewController.Hide();
        }

        private IViewController GetViewController(ViewType viewType)
        {
            var viewController = _views.FirstOrDefault(a => a.ViewType == viewType);

            if (viewController == null)
            {
                throw new NullReferenceException("There is no appropriate view");
            }

            return viewController;
        }
    }
}