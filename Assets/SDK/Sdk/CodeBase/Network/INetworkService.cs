using System;
using System.Collections;
using UnityEngine;

namespace SDK.Sdk.CodeBase.Network
{
    public interface INetworkService
    {
        IEnumerator GetRequest(string url, Action<byte[]> returnedData = null);
        IEnumerator GetRequest(string url, Action<Texture> returnedData = null);
        IEnumerator PostRequest(string url, string body, Action<string> returnedData = null);
    }
}