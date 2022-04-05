using System.Threading.Tasks;
using Sdk.CodeBase.Constants;
using Sdk.CodeBase.ResourcesManagement;
using Sdk.CodeBase.UI.Factories;
using UnityEngine;

namespace Sdk.CodeBase.UI
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