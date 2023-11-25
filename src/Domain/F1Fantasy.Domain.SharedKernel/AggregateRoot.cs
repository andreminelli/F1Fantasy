namespace F1Fantasy.Domain.SharedKernel;

public class AggregateRoot<TId> : Entity<TId>
    where TId : class
{
    private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
    public virtual IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents;

    protected virtual void AddDomainEvent(IDomainEvent newEvent)
    {
        _domainEvents.Add(newEvent);
    }

    public virtual void ClearEvents()
    {
        _domainEvents.Clear();
    }
}
