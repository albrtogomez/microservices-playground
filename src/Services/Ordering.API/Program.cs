using Microsoft.EntityFrameworkCore;
using Ordering.Application;
using Ordering.Application.Common.Interfaces;
using Ordering.Infrastructure.Persistence;
using Ordering.Infrastructure.Persistence.Seeding;
using Ordering.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Application layer services
builder.Services.AddApplication();

// Infrastructure layer services
builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetSection("OrderingDatabase").GetChildren().First().Value));
builder.Services.AddScoped<IDataContext>(provider => provider.GetRequiredService<DataContext>());
builder.Services.AddScoped<IDomainEventService, DomainEventService>();

// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<DataContext>();

        if (context.Database.IsNpgsql())
        {
            context.Database.Migrate();
        }

        await OrderingSeed.SeedSampleData(context);
    }
    catch (Exception ex)
    {
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

        logger.LogError(ex, "Error migrating or seeding");

        throw;
    }
}

app.MapControllers();

app.Run();