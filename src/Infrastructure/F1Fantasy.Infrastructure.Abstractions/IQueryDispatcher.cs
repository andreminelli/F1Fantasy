namespace F1Fantasy.Infrastructure.Abstractions;

public interface IQueryDispatcher
{
    Task<TQueryResult> Dispatch<TQuery, TQueryResult>(TQuery query, CancellationToken cancellationToken)
        where TQuery : IQuery<TQueryResult>
        where TQueryResult : IQueryResult;
}
