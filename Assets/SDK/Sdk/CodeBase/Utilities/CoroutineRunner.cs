using System.Collections;
using UnityEngine;

namespace SDK.Sdk.CodeBase.Utilities
{
    public class CoroutineRunner : MonoBehaviour, ICoroutineRunner
    {
        public void RunCoroutine(IEnumerator coroutine)
        {
            StartCoroutine(coroutine);
        }
    }
}