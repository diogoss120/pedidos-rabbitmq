using Microsoft.AspNetCore.Mvc;
using Order.Api.DTOs;
using Order.Api.Services.Interfaces;

namespace Order.Api.Setup
{
    public static class Endpoints
    {
        public static void AddEndpoints(this WebApplication app)
        {
            app.MapGet("/", () => "Hello world!").WithName("Home");

            app.MapGroup("Orderrs")
                .MapPost("/orders", async ([FromBody] CreateOrderRequest request, [FromServices] IOrderService service) =>
                {
                    var orderId = await service.CreateOrderAsync(request);

                    return Results.Accepted($"/orders/{orderId}", new { OrderId = orderId });
                });

        }
    }

}
