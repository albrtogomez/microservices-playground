namespace Ordering.Application.Features.Orders.Queries;

public class OrderDto : IMapFrom<Order>
{
    public int OrderId { get; set; }

    public decimal TotalPrice { get; set; }

    public DateTime OrderDate { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Order, OrderDto>();
    }
}