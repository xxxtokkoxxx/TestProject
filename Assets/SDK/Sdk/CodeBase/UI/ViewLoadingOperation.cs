using System.Threading.Tasks;
using SDK.Sdk.CodeBase.Constants;
using SDK.Sdk.CodeBase.ResourcesManagement;
using SDK.Sdk.CodeBase.UI.Factories;
using UnityEngine;

namespace SDK.Sdk.CodeBase.UI
{
    public class ViewLoadingOperation : ILoadingOperation
    {
        private readonly IViewFactory _viewFactory;

        public ViewLoadingOperation(IViewFactory viewFactory)
        {
            _viewFactory = viewFactory;
        }
        
        public async Task Load()
        {
            SetViews();
            await Task.CompletedTask;
        }

        private void SetViews()
        {
            var views = Resources.LoadAll<BaseView>(AssetsDataPath.Views);
            _viewFactory.SetViews(views);
        }
    }
}