using System;
using Newtonsoft.Json;
using Sdk.CodeBase.Data.RunTime;
using Sdk.CodeBase.Network;
using Sdk.CodeBase.SdkCore;
using Sdk.CodeBase.SdkStateMachine;
using Sdk.CodeBase.SdkStateMachine.States;
using Sdk.Extensions;
using UnityEngine;
using Zenject;

namespace Sdk.CodeBase
{
    public class SdkBootstrapper : MonoBehaviour
    {
        private IStateMachine _stateMachine;
        private INetworkService _networkService;
        private IStateMachineInitializer _stateMachineInitializer;
        private ISdk _sdk;

        [Inject]
        public void Construct(IStateMachineInitializer stateMachineInitializer,
            IStateMachine stateMachine,
            INetworkService networkService,
            ISdk sdk)
        {
            _sdk = sdk;
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
                _sdk.ShowVideoAdvertisement();
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _sdk.HideVideoAdvertisement();
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                _sdk.ShowPurchase();
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                _sdk.HidePurchase();
            }
        }
    }
}