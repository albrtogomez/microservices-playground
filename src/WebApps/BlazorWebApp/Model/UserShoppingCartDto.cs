namespace BlazorWebApp.Model;

public class UserShoppingCartDto
{
    public string UserId { get; set; } = null!;

    public List<ShoppingCartItemDto> CartItems { get; set; } = new List<ShoppingCartItemDto>();

    public decimal TotalPrice { get; set; }
}
