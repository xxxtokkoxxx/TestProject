using System.Collections.Generic;
using System.Linq;

namespace SDK.Sdk.CodeBase.Messenger
{
    public class MessengerService : IMessengerService
    {
        private List<IListener> _listeners = new List<IListener>();
        
        public void Send(IMessage message)
        {
            foreach (var listener in _listeners.ToList())
            {
                listener.Receive(message);
            }
        }
        
        public void Register(IListener listener)
        {
            _listeners.Add(listener);
        }

        public void UnRegister(IListener listener)
        {
            if (_listeners.Contains(listener))
            {
                _listeners.Remove(listener);
            }
        }
    }
}