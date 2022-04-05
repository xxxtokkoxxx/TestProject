using System.Collections.Generic;
using System.Threading.Tasks;
using Application.CodeBase.ResourcesManagement;
using UnityEngine;

namespace Application.CodeBase.SdkStateMachine.States
{
    public class BootstrapState : IBootstrapState
    {
        private readonly ILoadingOperation[] _loadingOperations;

        public BootstrapState(ILoadingOperation [] loadingOperations)
        {
            _loadingOperations = loadingOperations;
        }
        
        public async void Enter()
        {
            Debug.Log("enter bootstrap");
            await LoadResources();
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