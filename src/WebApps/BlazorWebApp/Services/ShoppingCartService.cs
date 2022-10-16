using BlazorWebApp.Model;
using System.Net.Http;
using System;
using System.Text;
using System.Text.Json;

namespace BlazorWebApp.Services;

public class ShoppingCartService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _shoppingCartAPIBaseUrl;
    private readonly string _userId;

    public ShoppingCartService(IHttpClientFactory clientFactory)
    {
        _httpClientFactory = clientFactory;
        _shoppingCartAPIBaseUrl = "http://host.docker.internal:7102/shoppingcart/";
        _userId = Guid.NewGuid().ToString();
    }

    public async Task<UserShoppingCartDto> GetCurrentUserShoppingCart()
    {
        var request = new HttpRequestMessage(HttpMethod.Get,
            Path.Combine(_shoppingCartAPIBaseUrl, _userId));

        var client = _httpClientFactory.CreateClient();

        try
        {
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var shoppingCart = await JsonSerializer.DeserializeAsync
                    <UserShoppingCartDto>(responseStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return shoppingCart ?? new UserShoppingCartDto();
            }
        }
        catch (HttpRequestException ex)
        {
        }

        return new UserShoppingCartDto();
    }

    public async Task<int?> GetCurrentUserShoppingCartItemCount()
    {
        var request = new HttpRequestMessage(HttpMethod.Get,
            Path.Combine(_shoppingCartAPIBaseUrl, $"count/{_userId}"));

        var client = _httpClientFactory.CreateClient();

        try
        {
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                if (int.TryParse((await response.Content.ReadAsStringAsync()).Replace("\"", ""), out int itemCount))
                {
                    return itemCount;
                }
            }
        }
        catch (HttpRequestException ex)
        {
        }

        return null;
    }

    public async Task<PutMovieInShoppingCartResult> PutMovieInShoppingCart(MovieDto movie)
    {
        var shoppingCart = await GetCurrentUserShoppingCart();

        if (shoppingCart.CartItems.Any(m => m.MovieId == movie.Id))
        {
            return PutMovieInShoppingCartResult.AlreadyPresent;
        }

        shoppingCart.CartItems.Add(new ShoppingCartItemDto()
        {
            MovieId = movie.Id,
            MovieTitle = movie.Title,
            Price = movie.Price
        });

        var client = _httpClientFactory.CreateClient();

        var requestContent = new StringContent(JsonSerializer.Serialize(shoppingCart), Encoding.UTF8, "application/json");

        try
        {
            var response = await client.PutAsync(_shoppingCartAPIBaseUrl, requestContent);

            response.EnsureSuccessStatusCode();

            return PutMovieInShoppingCartResult.Ok;
        }
        catch (HttpRequestException ex)
        {
        }

        return PutMovieInShoppingCartResult.Failed;
    }

    public async Task RemoveMovieFromShoppingCart(string movieId)
    {
        var shoppingCart = await GetCurrentUserShoppingCart();

        var movie = shoppingCart.CartItems.Find(m => m.MovieId == movieId);

        if (movie is null)
            throw new KeyNotFoundException("Movie not found");

        shoppingCart.CartItems.Remove(movie);

        var client = _httpClientFactory.CreateClient();

        var requestContent = new StringContent(JsonSerializer.Serialize(shoppingCart), Encoding.UTF8, "application/json");

        try
        {
            var response = await client.PutAsync(_shoppingCartAPIBaseUrl, requestContent);

            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException ex)
        {
        }
    }
}

public enum PutMovieInShoppingCartResult
{
    Ok,
    AlreadyPresent,
    Failed
}
