using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace WongaLibrary.Utilities
{
    public class RabbitMqService : IMessagerService
    {
        ConnectionFactory _factory;

        public RabbitMqService()
        {
            _factory = new ConnectionFactory() { HostName = "localhost" };
        }

        public void SendMessage(string message, string queue)
        {
            using var connection = _factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: message,
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "",
                                 routingKey: queue,
                                 basicProperties: null,
                                 body: body);
        }

        public string GetMessage(string queue)
        {
            string message = "";

            using var connection = _factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: queue,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                message = Encoding.UTF8.GetString(body);
            };
            channel.BasicConsume(queue: queue,
                                 autoAck: true,
                                 consumer: consumer);

            while (string.IsNullOrEmpty(message)) { }

            return message;
        }
    }
}
