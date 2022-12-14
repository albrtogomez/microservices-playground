namespace Ordering.Domain.Entities;

public class Order
{
    public int OrderId { get; set; }

    public string CustomerId { get; set; } = null!;

    public decimal TotalPrice { get; set; }

    public DateTime OrderDate { get; set; }
}