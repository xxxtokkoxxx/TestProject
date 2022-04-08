namespace SDK.Sdk.CodeBase.Messenger
{
    public interface IMessengerService
    {
        void Send(IMessage message);
        void Register(IListener listener);
        void UnRegister(IListener listener);
    }
}