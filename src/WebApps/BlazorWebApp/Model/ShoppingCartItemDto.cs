namespace BlazorWebApp.Model;

public class ShoppingCartItemDto
{
    public string MovieId { get; set; } = null!;

    public string MovieTitle { get; set; } = null!;

    public decimal Price { get; set; }
}
