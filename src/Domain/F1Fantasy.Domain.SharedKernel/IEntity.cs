namespace F1Fantasy.Domain.SharedKernel;

public interface IEntity<TId>
    where TId: class
{
    TId Id { get; }
}

