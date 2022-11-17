using BlazorWebApp.Model;
using System.Text.Json;

namespace BlazorWebApp.Services;

public class OrderingService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _orderingAPIBaseUrl;
    private readonly string _userId;

    public event EventHandler? OnChange;

    public OrderingService(IHttpClientFactory clientFactory)
    {
        _httpClientFactory = clientFactory;
        _orderingAPIBaseUrl = "http://host.docker.internal:7103/orders/";
        _userId = "3852e76d-e4ad-439f-81ab-1d6a4e48a63b";
    }

    public async Task<List<OrderListDto>> GetCurrentUserOrders()
    {
        var request = new HttpRequestMessage(HttpMethod.Get,
            Path.Combine(_orderingAPIBaseUrl, $"user/{_userId}"));

        var client = _httpClientFactory.CreateClient();

        try
        {
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                var ordersList = await JsonSerializer.DeserializeAsync
                    <List<OrderListDto>>(responseStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return ordersList ?? new List<OrderListDto>();
            }
        }
        catch (HttpRequestException)
        {
        }

        return new List<OrderListDto>();
    }
}