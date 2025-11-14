using Order.Api.DTOs;

namespace Order.Api.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Guid> CreateOrderAsync(CreateOrderRequest request);

        Task<CreateOrderRequest?> GetOrder(Guid id);
    }
}
