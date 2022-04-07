using System;
using Sdk.CodeBase.Network;
using Sdk.CodeBase.SdkStateMachine;
using Sdk.CodeBase.SdkStateMachine.States;
using UnityEngine;
using Zenject;

namespace Sdk.CodeBase
{
    public class SdkBootstrapper : MonoBehaviour
    {
        private IStateMachine _stateMachine;
        private IStateMachineInitializer _stateMachineInitializer;
        private INetworkService _networkService;

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
                var json = new TestJson();
                
                json.Name = "aasd";
                json.Wings = "wings";
                
                var jsonString = JsonUtility.ToJson(json);
                Debug.Log(jsonString);
                StartCoroutine(_networkService.PostRequest(ApiCredentials.MainUrl + ApiCredentials.PurchaseUrl, jsonString, ReturnedData));
            }
        }

        private void ReturnedData(string s)
        {
            Debug.Log(s);
        }

        [Serializable]
        public class TestJson
        {
            public string Name;
            public string Wings;
        }
    }
}