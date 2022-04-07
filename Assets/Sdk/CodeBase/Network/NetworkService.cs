using System;
using System.Collections;
using System.Text;
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

        public IEnumerator PostRequest(string url, string body, Action<string> returnedData = null)
        {
            var request = new UnityWebRequest(url, UnityWebRequest.kHttpVerbPOST);
            byte[] bodyRaw = Encoding.UTF8.GetBytes(body);
            
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();
            
            request.SetRequestHeader("Content-Type", "application/json");
            
            yield return request.SendWebRequest();

            returnedData?.Invoke(request.downloadHandler.text);
        }
    }
}