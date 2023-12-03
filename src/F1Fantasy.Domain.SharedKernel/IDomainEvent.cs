namespace F1Fantasy.Domain.SharedKernel;

public interface IDomainEvent
{
    Guid EventId { get; }
}
