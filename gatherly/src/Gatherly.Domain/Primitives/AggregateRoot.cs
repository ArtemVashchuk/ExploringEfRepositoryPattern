namespace Gatherly.Domain.Primitives;

public abstract class AggregateRoot : Entity
{
    private readonly List<IDomainEvent> _domainEvents = [];

    protected AggregateRoot(Guid id)
        : base(id)
    {
    }

    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}