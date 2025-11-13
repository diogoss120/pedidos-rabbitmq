using Order.Api.Services.Interfaces;
using Order.Api.DTOs;

namespace Order.Api.Services
{
    public class OrderService : IOrderService
    {
        public async Task<Guid> CreateOrderAsync(CreateOrderRequest request)
        {
            return Guid.NewGuid();
        }
    }
}
