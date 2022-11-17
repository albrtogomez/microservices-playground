namespace BlazorWebApp.Model;

public class OrderListDto
{
    public int OrderId { get; set; }

    public decimal TotalPrice { get; set; }

    public DateTime OrderDate { get; set; }
}
