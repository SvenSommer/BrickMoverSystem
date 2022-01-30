using System;

namespace BrickHandler.RabbitMQAdapter.Exceptions
{
    public class MessageHandlerNotFoundException : Exception
    {
        public MessageHandlerNotFoundException(string messageType) :
            base($"Message handler not found for the message type: {messageType}")
        {

        }
    }
}
