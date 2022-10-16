using Ordering.Application.Common.Interfaces;
using Ordering.Infrastructure.Persistence;
using Ordering.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Infrastructure;

public static class DependencyInjection
{ 
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("OrderingDatabase");
        services.AddDbContext<DataContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddScoped<IDataContext>(provider => provider.GetRequiredService<DataContext>());

        services.AddScoped<IDomainEventService, DomainEventService>();

        return services;
    }
}
