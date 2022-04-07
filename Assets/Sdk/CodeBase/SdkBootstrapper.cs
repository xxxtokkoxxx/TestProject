using System;
using Newtonsoft.Json;
using Sdk.CodeBase.Data.RunTime;
using Sdk.CodeBase.Network;
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
                var json = new PurchaseData();
                var jsonString = JsonConvert.SerializeObject(json);

                StartCoroutine(_networkService.PostRequest(ApiCredentials.MainUrl + ApiCredentials.PurchaseUrl, jsonString, ReturnedData));
            }
        }

        private void ReturnedData(string s)
        {
            var jsonString = s.GetModifiedJson("PurchaseInfo");
            var json = JsonConvert.DeserializeObject<PurchaseData>(jsonString);
            Debug.Log(jsonString);
        }
    }
}