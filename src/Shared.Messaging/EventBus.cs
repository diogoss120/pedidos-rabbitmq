using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Shared.Messaging
{
    public class EventBus : IEventBus
    {
        public async Task PublishAsync<T>(string key, T message)
        {
            // todo: mover esses dados de acesso para o appsettings depois
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            var connection = await factory.CreateConnectionAsync();

            using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(
                key,
                durable: true,
                exclusive: false,
                autoDelete: false
            );

            var json = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);

            var props = new BasicProperties();
            props.DeliveryMode = DeliveryModes.Persistent;

            await channel.BasicPublishAsync(string.Empty, key, false, props, body);
        }
    }
}
