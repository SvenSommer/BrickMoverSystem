using System.Threading.Tasks;
using BrickHandler.Messages.Messages;

namespace BrickHandler.RabbitMQAdapter.MessageHandling
{
    public interface IMessageHandler<T> where T: IMessage
    {
        Task Handle(T message);
    }
}
