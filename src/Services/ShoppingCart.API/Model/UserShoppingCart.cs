namespace ShoppingCart.API.Model;

public class UserShoppingCart
{
    public string UserId { get; set; } = null!;

    public List<ShoppingCartItem> CartItems { get; set; } = new List<ShoppingCartItem>();

    public decimal TotalPrice => CartItems.Sum(x => x.Price);

    public UserShoppingCart(string userId)
    {
        UserId = userId;
    }
}
