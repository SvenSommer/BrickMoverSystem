using System;
using System.Collections.Generic;
using System.Text;

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
