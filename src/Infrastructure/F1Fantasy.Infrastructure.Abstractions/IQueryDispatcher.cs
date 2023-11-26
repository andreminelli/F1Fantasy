namespace F1Fantasy.Infrastructure.Abstractions;

public interface IQueryDispatcher
{
    Task<TQueryResult> Dispatch<TQueryResult>(IQuery<TQueryResult> query, CancellationToken cancellationToken);
}
