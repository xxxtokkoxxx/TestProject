using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace Sdk.CodeBase.Network
{
    public class NetworkService : INetworkService
    {
        public IEnumerator GetRequest(string url, Action<byte[]> returnedData = null)
        {
            var www = UnityWebRequest.Get(url);

            yield return www.SendWebRequest();

            if (www.isHttpError || www.isNetworkError)
            {
                Debug.LogError(www.error);
                yield break;
            }

            returnedData?.Invoke(www.downloadHandler.data);
        }
    }
}