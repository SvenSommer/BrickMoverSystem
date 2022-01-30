using BrickHandler.Messages.Messages;
using BrickHandler.RabbitMQAdapter.MessageHandling;

namespace BrickHandler.RabbitMQAdapter
{

    public delegate void MessageReceived(MessageReceivedEventArgs args);

    public interface IRabbitMQAdapter
    {
        event MessageReceived MessageReceived;
        void TryConnect();
        void BasicPublish(ICommand command, string destination);
        void BasicPublish(IEvent @event);
        void StartConsuming();
    }
}
