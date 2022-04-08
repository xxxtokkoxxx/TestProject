using System.Collections.Generic;
using System.Threading.Tasks;
using SDK.Sdk.CodeBase.ResourcesManagement;
using SDK.Sdk.CodeBase.UI;

namespace SDK.Sdk.CodeBase.SdkStateMachine.States
{
    public class BootstrapState : IBootstrapState
    {
        private readonly ILoadingOperation[] _loadingOperations;
        private readonly IStateMachine _stateMachine;
        private readonly IScreenServiceInitializer _screenServiceInitializer;

        public BootstrapState(ILoadingOperation [] loadingOperations,
            IStateMachine stateMachine,
            IScreenServiceInitializer screenServiceInitializer)
        {
            _loadingOperations = loadingOperations;
            _stateMachine = stateMachine;
            _screenServiceInitializer = screenServiceInitializer;
        }
        
        public async void Enter()
        {
            await LoadResources();
            _screenServiceInitializer.Initialize();
            
            _stateMachine.Enter<PlayModeState>();
        }

        public void Exit() { }
        
        private async Task LoadResources()
        {
            var loadingOperations = new List<Task>();
            
            foreach (var operation in _loadingOperations)
            {
                loadingOperations.Add(operation.Load());
            }
            
            await Task.WhenAll(loadingOperations);
        }
    }
}