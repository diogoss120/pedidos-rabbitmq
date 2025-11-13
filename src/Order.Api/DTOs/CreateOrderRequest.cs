namespace Order.Api.DTOs
{
    public class CreateOrderRequest
    {
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;

        public List<CreateOrderItemRequest> Items { get; set; } = new();

        public string PaymentMethod { get; set; } = string.Empty;
    }

    public class CreateOrderItemRequest
    {
        public string ProductName { get; set; }           // Ex: "Mouse Gamer"
        public int Quantity { get; set; }                 // Ex: 2
        public decimal UnitPrice { get; set; }            // Ex: 150.00m
    }
}
