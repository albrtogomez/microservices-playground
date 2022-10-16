using BlazorWebApp.Model;
using System.Net.Http;
using System;
using System.Text;
using System.Text.Json;
using BlazorWebApp.Pages;

namespace BlazorWebApp.Services;

public class MovieCatalogService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _movieCatalogBaseUrl;

    public MovieCatalogService(IHttpClientFactory clientFactory)
    {
        _httpClientFactory = clientFactory;
        _movieCatalogBaseUrl = "http://host.docker.internal:7101/movies/";
    }

    public async Task<MovieDto[]?> GetMoviesAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, _movieCatalogBaseUrl);

        var client = _httpClientFactory.CreateClient();

        try
        {
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                return await JsonSerializer.DeserializeAsync
                    <MovieDto[]>(responseStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            else
            {
                throw new Exception("Failed to fetch data");
            }
        }
        catch (HttpRequestException)
        {
            throw;
        }
    }
}