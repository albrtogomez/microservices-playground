namespace Ordering.Infrastructure.Persistence.Seeding
{
    public static class OrderingSeed
    {
        public static async Task SeedSampleData(DataContext context)
        {
            if (!context.Orders.Any())
            {
                // Create sample orders
            }
        }
    }
}
