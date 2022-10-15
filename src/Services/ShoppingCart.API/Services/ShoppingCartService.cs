using Microsoft.Extensions.Caching.Distributed;
using ShoppingCart.API.Model;
using System.Text.Json;

namespace ShoppingCart.API.Services;

public class ShoppingCartService
{
    private readonly IDistributedCache _cacheService;

	public ShoppingCartService(IDistributedCache cacheService)
	{
		_cacheService = cacheService;
	}

	public async Task<UserShoppingCart> GetAsync(string userId)
	{
		var shoppingCart = await _cacheService.GetStringAsync(userId);

        if (string.IsNullOrEmpty(shoppingCart))
		{
			return new UserShoppingCart(userId);
        }

		return JsonSerializer.Deserialize<UserShoppingCart>(shoppingCart) ?? new UserShoppingCart(userId);
    }

    public async Task UpdateAsync(UserShoppingCart shoppingCart) =>
		await _cacheService.SetStringAsync(shoppingCart.UserId, JsonSerializer.Serialize(shoppingCart));

	public async Task EmptyUserShoppingCart(string userId) =>
		await _cacheService.RemoveAsync(userId);
}
