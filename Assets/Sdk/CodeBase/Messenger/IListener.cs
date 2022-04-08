namespace Sdk.CodeBase.Messenger
{
    public interface IListener
    {
        void Receive(IMessage message);
    }
}
