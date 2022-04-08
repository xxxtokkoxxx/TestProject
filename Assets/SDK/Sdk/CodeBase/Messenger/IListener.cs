namespace SDK.Sdk.CodeBase.Messenger
{
    public interface IListener
    {
        void Receive(IMessage message);
    }
}
