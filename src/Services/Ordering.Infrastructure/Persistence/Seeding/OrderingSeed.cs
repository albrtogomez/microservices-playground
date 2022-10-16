using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Persistence.Seeding
{
    public static class OrderingSeed
    {
        public static async Task SeedSampleData(DataContext context)
        {
            if (!context.Orders.Any())
            {
                context.Orders.AddRange(new List<Order>()
                {
                    new Order()
                    {
                        OrderId = Guid.NewGuid(),
                        CustomerId = "3852e76d-e4ad-439f-81ab-1d6a4e48a63b",
                        OrderDate = DateTime.Today,
                        TotalPrice = 14.98m
                    },
                    new Order()
                    {
                        OrderId = Guid.NewGuid(),
                        CustomerId = "3852e76d-e4ad-439f-81ab-1d6a4e48a63b",
                        OrderDate = DateTime.Today.AddDays(-10),
                        TotalPrice = 3.99m
                    },
                    new Order()
                    {
                        OrderId = Guid.NewGuid(),
                        CustomerId = "3852e76d-e4ad-439f-81ab-1d6a4e48a63b",
                        OrderDate = DateTime.Today.AddDays(-32),
                        TotalPrice = 1.49m
                    },
                    new Order()
                    {
                        OrderId = Guid.NewGuid(),
                        CustomerId = "3852e76d-e4ad-439f-81ab-1d6a4e48a63b",
                        OrderDate = DateTime.Today.AddDays(-67),
                        TotalPrice = 8.99m
                    },
                });

                await context.SaveChangesAsync();
            }
        }
    }
}
