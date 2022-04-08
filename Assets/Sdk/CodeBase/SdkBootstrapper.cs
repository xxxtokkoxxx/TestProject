using Sdk.CodeBase.Network;
using Sdk.CodeBase.SdkCore;
using Sdk.CodeBase.SdkStateMachine;
using Sdk.CodeBase.SdkStateMachine.States;
using UnityEngine;
using Zenject;

namespace Sdk.CodeBase
{
    public class SdkBootstrapper : MonoBehaviour
    {
        private IStateMachine _stateMachine;
        private INetworkService _networkService;
        private IStateMachineInitializer _stateMachineInitializer;

        [Inject]
        public void Construct(IStateMachineInitializer stateMachineInitializer,
            IStateMachine stateMachine,
            INetworkService networkService)
        {
            _networkService = networkService;
            _stateMachine = stateMachine;
            _stateMachineInitializer = stateMachineInitializer;
        }

        private void Start()
        {
            DontDestroyOnLoad(this);
            
            _stateMachineInitializer.Initialize();
            _stateMachine.Enter<BootstrapState>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SdkCore.Sdk.Instance.ShowVideoAdvertisement();
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SdkCore.Sdk.Instance.HideVideoAdvertisement();
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SdkCore.Sdk.Instance.ShowPurchase();
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                SdkCore.Sdk.Instance.HidePurchase();
            }
        }
    }
}