using ShoppingCart.API.Model;
using ShoppingCart.API.Services;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddStackExchangeRedisCache(options =>
    options.Configuration = builder.Configuration.GetSection("ShoppingCartCache").GetChildren().First().Value);

builder.Services.AddSingleton<ShoppingCartService>();

// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Minimal API endpoints
app.MapGet("/shoppingcart/{userId}", async (string userId, ShoppingCartService shoppingCartService) =>
    await shoppingCartService.GetAsync(userId)
        is UserShoppingCart shoppingCart
            ? Results.Ok(shoppingCart)
            : Results.NotFound());

app.MapGet("/shoppingcart/count/{userId}", async (string userId, ShoppingCartService shoppingCartService) =>
    await shoppingCartService.GetAsync(userId)
        is UserShoppingCart shoppingCart
            ? Results.Ok(JsonSerializer.Serialize(shoppingCart.CartItems.Count))
            : Results.NotFound());

app.MapPut("/shoppingcart", async (UserShoppingCart updatedShoppingCart, ShoppingCartService shoppingCartService) =>
{
    await shoppingCartService.UpdateAsync(updatedShoppingCart);

    return Results.NoContent();
});

app.MapDelete("/shoppingcart/{userId}", async (string userId, ShoppingCartService shoppingCartService) =>
{
    await shoppingCartService.EmptyUserShoppingCartAsync(userId);

    return Results.Ok();
});

app.Run();