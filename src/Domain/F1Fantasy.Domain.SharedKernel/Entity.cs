namespace F1Fantasy.Domain.SharedKernel;

public abstract class Entity<TId> : IEntity<TId>
    where TId : class 
{
    public TId Id { get; protected set; }
}
