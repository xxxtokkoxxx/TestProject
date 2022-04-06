using System;
using System.Collections;

namespace Sdk.CodeBase.Network
{
    public interface INetworkService
    {
        IEnumerator GetRequest(string url, Action<byte[]> returnedData = null);
    }
}