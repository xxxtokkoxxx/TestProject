using SDK.Sdk.CodeBase.Messenger;

namespace SDK.Sdk.CodeBase.SdkCore.Advertisements
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