using MovieCatalog.API.Model;
using MovieCatalog.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<MovieCatalogDatabaseSettings>(
    builder.Configuration.GetSection("MovieCatalogDatabase"));

builder.Services.AddSingleton<MovieCatalogService>();

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

app.MapGet("/movies", async (MovieCatalogService movieCatalogService) =>
    await movieCatalogService.GetAsync());

app.MapGet("/movies/{id}", async (string id, MovieCatalogService movieCatalogService) =>
    await movieCatalogService.GetAsync(id)
        is Movie movie
            ? Results.Ok(movie)
            : Results.NotFound());

app.MapPost("/movies", async (Movie movie, MovieCatalogService movieCatalogService) =>
{
    await movieCatalogService.CreateAsync(movie);

    return Results.Created($"/movies/{movie.Id}", movie);
});

app.MapPut("/movies/{id}", async (string id, Movie updatedMovie, MovieCatalogService movieCatalogService) =>
{
    var movie = await movieCatalogService.GetAsync(id);

    if (movie is null)
        return Results.NotFound();

    await movieCatalogService.UpdateAsync(id, updatedMovie);

    return Results.NoContent();
});

app.MapDelete("/movies/{id}", async (string id, MovieCatalogService movieCatalogService) =>
{
    if (await movieCatalogService.GetAsync(id) is Movie movie)
    {
        await movieCatalogService.RemoveAsync(id);

        return Results.Ok(movie);
    }

    return Results.NotFound();
});

app.Run();