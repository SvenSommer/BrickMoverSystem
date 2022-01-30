using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using BrickHandler.Messages.Messages;
using BrickHandler.RabbitMQAdapter.Exceptions;
using BrickHandler.RabbitMQAdapter.MessageHandling;
using BrickHandler.RabbitMQAdapter.ReflectUtils;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;
using RabbitMQ.Client.Exceptions;

namespace BrickHandler.RabbitMQAdapter
{
    public class MessageBusEndpoint
    {
        private readonly IRabbitMQAdapter _rabbitMqAdapter;
        private readonly IReflectionUtil _reflectionUtil = new ReflectionUtil();

        public MessageBusEndpoint(IRabbitMQAdapter rabbitMQAdapter)
        {
            _rabbitMqAdapter = rabbitMQAdapter;
        }

        public void Start()
        {
            _rabbitMqAdapter.MessageReceived += RabbitMqAdapter_MessageReceived;
            _rabbitMqAdapter.StartConsuming();
        }

        private void RabbitMqAdapter_MessageReceived(MessageReceivedEventArgs args)
        {
            IEnumerable<Assembly> assemblies = _reflectionUtil.GetAssemblies();
            IEnumerable<Type> types = _reflectionUtil.GetTypes(assemblies);

            Type messageType = types.FirstOrDefault(m => m.Name.Equals(args.Type));

            if (messageType == null)
            {
                throw new MessageHandlerNotFoundException(args.Type);
            }

            Type genericHandlerInterfaceType = typeof(IMessageHandler<>).MakeGenericType(messageType);
            IEnumerable<Type> handlerClassLookup = Assembly.GetEntryAssembly()?.GetTypes().Where(t => t.GetInterfaces().Contains(genericHandlerInterfaceType));


            if (!handlerClassLookup.Any())
            {
                throw new MessageHandlerNotFoundException(args.Type);
            }

            if (handlerClassLookup.Count() > 1)
            {
                throw new MultipleMessageHandlerFoundException(args.Type);
            }

            Type handlerClass = handlerClassLookup.First();
            object? handlerInstance = Activator.CreateInstance(handlerClass);

            object message = JsonConvert.DeserializeObject(args.Payload.ToString(), messageType);
            handlerClass.GetMethod("Handle")?.Invoke(handlerInstance, new[] { message });
        }


        /// <summary>
        /// Sends the command to the given endpoint.
        /// </summary>
        /// <param name="command">Command to send.</param>
        /// <param name="endpoint">The endpoint which is the command will be sent to.</param>
        public void Send(ICommand command, string endpoint)
        {
            if (string.IsNullOrEmpty(endpoint))
            {
                throw new ArgumentException("An endpoint must be provided to send a command.");
            }

            _rabbitMqAdapter.BasicPublish(command, endpoint);
        }

        /// <summary>
        /// Publishes the event to all endpoints.
        /// </summary>
        public void Publish(IEvent @event)
        {
            _rabbitMqAdapter.BasicPublish(@event);
        }

    }
}
