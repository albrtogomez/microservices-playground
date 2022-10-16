using Ordering.Domain.Common;

namespace Ordering.Application.Common.Interfaces;

public interface IDomainEventService
{
    Task Publish(DomainEvent domainEvent);
}
