namespace EventBus.Messages
{
    public class ShoppingCartCheckoutEvent
    {
        public string CustomerId { get; set; } = null!;

        public decimal TotalPrice { get; set; }
    }
}
