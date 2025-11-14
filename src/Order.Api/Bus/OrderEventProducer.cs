using Order.Api.Bus.Interfaces;
using Order.Api.Bus.Messages;
using Order.Api.DTOs;

namespace Order.Api.Bus
{
    public class OrderEventProducer : IOrderEventProducer
    {
        private readonly IEventBus _eventBus;

        public OrderEventProducer(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task PublishOrderCreatedAsync(CreateOrderRequest order)
        {
            var message = new OrderCreatedMessage
            {
                Id = order.Id,
                CustomerName = order.CustomerName,
                CustomerEmail = order.CustomerEmail,
                Items = order.Items.Select(i => new OrderItemMessage
                {
                    ProductName = i.ProductName,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice
                }).ToList()
            };

            await _eventBus.PublishAsync("order.created", message);
        }
    }
}
