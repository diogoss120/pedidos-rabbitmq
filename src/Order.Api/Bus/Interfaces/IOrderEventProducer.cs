using Order.Api.DTOs;

namespace Order.Api.Bus.Interfaces
{
    public interface IOrderEventProducer
    {
        Task PublishOrderCreatedAsync(CreateOrderRequest order);
    }
}
