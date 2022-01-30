using System;
using System.Net.Sockets;
using BrickHandler.Messages.Messages;
using BrickHandler.RabbitMQAdapter.Extensions;
using BrickHandler.RabbitMQAdapter.MessageHandling;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;

namespace BrickHandler.RabbitMQAdapter
{
    public class DefaultRabbitMQAdapter : IRabbitMQAdapter
    {
        /// <summary>
        /// Sending/Publishing can be performed via multiple channels, but subscribing/consuming channel must be single.
        /// </summary>
        private IModel consumerChannel;
        private bool _isConnected = false;
        private const string COMMAND_EXCHANGE_NAME = "CommandExchange";
        private const string EVENT_EXCHANGE_NAME = "EventExchange";
        private int retryCount = 3;
        private string queueName;
        private IConnection _connection;
        ConnectionFactory factory;
        public event MessageReceived MessageReceived;

        private IConnection connection
        {
            get
            {
                if (!_isConnected)
                {
                    TryConnect();
                }

                return _connection;
            }
        }

        public DefaultRabbitMQAdapter(string endpointName, string hostname, string username, string password)
        {
            queueName = endpointName;
            factory = new ConnectionFactory() { HostName = hostname, UserName = username, Password = password };
        }

        public void TryConnect()
        {
            RetryPolicy policy = RetryPolicy.Handle<SocketException>().Or<BrokerUnreachableException>()
                .WaitAndRetry(retryCount, op => TimeSpan.FromSeconds(Math.Pow(2, op)), (ex, time) =>
                {
                    Console.WriteLine("Couldn't connect to RabbitMQ server...");
                });

            policy.Execute(() =>
            {
                _connection = factory.CreateConnection();
                _isConnected = true;
                Console.WriteLine("connected!");
            });
        }

        public void BasicPublish(ICommand command, string destination)
        {
            using (IModel channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(COMMAND_EXCHANGE_NAME, type: ExchangeType.Direct);
                channel.BasicPublish(exchange: COMMAND_EXCHANGE_NAME, routingKey: destination, basicProperties: null, body: command.ToJson().ToByteArray());
            }
        }

        public void BasicPublish(IEvent @event)
        {
            using (IModel channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(EVENT_EXCHANGE_NAME, type: ExchangeType.Fanout);
                channel.BasicPublish(exchange: EVENT_EXCHANGE_NAME, routingKey: string.Empty, basicProperties: null, body: @event.ToJson().ToByteArray());
            }
        }

        public void StartConsuming()
        {
            consumerChannel = connection.CreateModel();
            consumerChannel.ExchangeDeclare(COMMAND_EXCHANGE_NAME, ExchangeType.Direct);
            consumerChannel.ExchangeDeclare(EVENT_EXCHANGE_NAME, ExchangeType.Fanout);

            QueueDeclareOk queue = consumerChannel.QueueDeclare(queue: queueName);
            consumerChannel.QueueBind(queue, COMMAND_EXCHANGE_NAME, routingKey: queueName);
            consumerChannel.QueueBind(queue, EVENT_EXCHANGE_NAME, routingKey: queueName);

            EventingBasicConsumer consumer = new EventingBasicConsumer(consumerChannel);

            consumerChannel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);

            consumer.Received += (model, ea) => {
                string messageBody = ea.Body.ToArray().GetPayloadString();
                MessageReceivedEventArgs args = JsonConvert.DeserializeObject<MessageReceivedEventArgs>(messageBody);
                MessageReceived.Invoke(args);
            };
        }
    }
}
