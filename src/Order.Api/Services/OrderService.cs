using Order.Api.Services.Interfaces;
using Order.Api.DTOs;
using Order.Api.Setup;

namespace Order.Api.Services
{
    public class OrderService : IOrderService
    {
        public async Task<Guid> CreateOrderAsync(CreateOrderRequest request)
        {
            // validar dados do pedido no futuro, usar o fluent validator
            request.Id = Guid.NewGuid();
            Banco.Orders.Add(request);
            return request.Id;
        }

        public async Task<CreateOrderRequest?> GetOrder(Guid id)
        {
            return Banco.Orders.FirstOrDefault(x => x.Id.Equals(id));
        }
    }
}
