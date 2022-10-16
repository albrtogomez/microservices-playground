using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Persistence.Seeding
{
    public static class OrderingSeed
    {
        public static async Task SeedSampleData(DataContext context)
        {
            if (!context.Orders.Any())
            {
                context.Orders.Add(new Order() { OrderId = Guid.NewGuid() });

                await context.SaveChangesAsync();
            }
        }
    }
}
