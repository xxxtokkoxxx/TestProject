namespace SDK.Sdk.CodeBase.UI
{
    public class ScreenServiceInitializer : IScreenServiceInitializer
    {
        private readonly IScreenService _screenService;
        private readonly IViewController[] _viewControllers;

        public ScreenServiceInitializer(IViewController[] viewControllers,
            IScreenService screenService)
        {
            _viewControllers = viewControllers;
            _screenService = screenService;
        }

        public void Initialize()
        {
            SetViewController();
        }

        private void SetViewController()
        {
            _screenService.SetControllers(_viewControllers); 
        }
    }
}