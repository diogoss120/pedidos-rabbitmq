using Order.Api.Services.Interfaces;
using Order.Api.DTOs;
using Order.Api.Setup;
using Order.Api.Bus.Interfaces;

namespace Order.Api.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderEventProducer _producer;

        public OrderService(IOrderEventProducer producer)
        {
            _producer = producer;
        }

        public async Task<Guid> CreateOrderAsync(CreateOrderRequest request)
        {
            // validar dados do pedido no futuro, usar o fluent validator

            request.Id = Guid.NewGuid();
            Banco.Orders.Add(request);

            await _producer.PublishOrderCreatedAsync(request);

            return request.Id;
        }

        public async Task<CreateOrderRequest?> GetOrder(Guid id)
        {
            return Banco.Orders.FirstOrDefault(x => x.Id.Equals(id));
        }
    }
}
