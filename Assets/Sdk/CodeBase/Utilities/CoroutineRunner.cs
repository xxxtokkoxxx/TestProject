using System.Collections;
using UnityEngine;

namespace Sdk.CodeBase.Utilities
{
    public class CoroutineRunner : MonoBehaviour, ICoroutineRunner
    {
        public void RunCoroutine(IEnumerator coroutine)
        {
            StartCoroutine(coroutine);
        }
    }
}