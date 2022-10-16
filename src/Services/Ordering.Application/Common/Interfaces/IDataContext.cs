namespace Ordering.Application.Common.Interfaces;

public interface IDataContext
{
    DbSet<Order> Orders { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}