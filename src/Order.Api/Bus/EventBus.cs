using Order.Api.Bus.Interfaces;

namespace Order.Api.Bus
{
    public class EventBus : IEventBus
    {
        public Task PublishAsync<T>(string key, T message)
        {
            // aqui seria o ponto onde eu de fato envio o evento para o rabbitmq
            throw new NotImplementedException();
        }
    }
}
