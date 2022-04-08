using Sdk.CodeBase.Messenger;

namespace Sdk.CodeBase.SdkCore.Advertisements
{
    public class AdsDataLoadedMessage : IMessage
    {
        public readonly byte[] Data;
        
        public AdsDataLoadedMessage(byte[] data)
        {
            Data = data;
        }
    }
}