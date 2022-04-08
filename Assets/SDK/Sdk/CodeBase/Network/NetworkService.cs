using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace SDK.Sdk.CodeBase.Network
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
        
        public IEnumerator GetRequest(string url, Action<Texture> returnedData = null)
        {
            var www = UnityWebRequestTexture.GetTexture(url);

            yield return www.SendWebRequest();

            if (www.isHttpError || www.isNetworkError)
            {
                Debug.LogError(www.error);
                yield break;
            }

            returnedData?.Invoke(DownloadHandlerTexture.GetContent(www));
        }

        public IEnumerator PostRequest(string url, string body, Action<string> returnedData = null)
        {
            var www = new UnityWebRequest(url, UnityWebRequest.kHttpVerbPOST);
            byte[] bodyRaw = Encoding.UTF8.GetBytes(body);
            
            www.uploadHandler = new UploadHandlerRaw(bodyRaw);
            www.downloadHandler = new DownloadHandlerBuffer();
            
            www.SetRequestHeader("Content-Type", "application/json");
            
            yield return www.SendWebRequest();

            if (www.isHttpError || www.isNetworkError)
            {
                Debug.LogError(www.error);
                yield break;
            }
            
            returnedData?.Invoke(www.downloadHandler.text);
        }
    }
}