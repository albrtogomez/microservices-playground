using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ordering.Application.Common.Behaviours;
using Ordering.Application.Common.Interfaces;
using Ordering.Infrastructure.Persistence;
using Ordering.Infrastructure.Persistence.Seeding;
using Ordering.Infrastructure.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddApplication();
//builder.Services.AddInfrastructure(builder.Configuration);

// Application Layer Services
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

// Infrastructure Layer Services
builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetSection("OrderingDatabase").GetChildren().First().Value));
builder.Services.AddScoped<IDataContext>(provider => provider.GetRequiredService<DataContext>());
builder.Services.AddScoped<IDomainEventService, DomainEventService>();

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

app.Run();