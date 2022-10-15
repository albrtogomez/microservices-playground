using ShoppingCart.API.Data;
using ShoppingCart.API.Model;
using ShoppingCart.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<ShoppingCartCacheSettings>(
    builder.Configuration.GetSection("ShoppingCartCache"));

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetSection("ShoppingCartCache").Get<ShoppingCartCacheSettings>().ConnectionString;
});

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

app.MapPut("/shoppingcart", async (UserShoppingCart updatedShoppingCart, ShoppingCartService shoppingCartService) =>
{
    await shoppingCartService.UpdateAsync(updatedShoppingCart);

    return Results.NoContent();
});

app.MapDelete("/shoppingcart/{userId}", async (string userId, ShoppingCartService shoppingCartService) =>
{
    await shoppingCartService.EmptyUserShoppingCart(userId);

    return Results.Ok();
});

app.Run();