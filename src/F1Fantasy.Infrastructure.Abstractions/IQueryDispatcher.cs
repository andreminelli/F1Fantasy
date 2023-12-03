namespace F1Fantasy.Infrastructure.Abstractions;

public interface IQueryDispatcher
{
    Task<TQueryResult> Dispatch<TQuery, TQueryResult>(IQuery<TQuery, TQueryResult> query, CancellationToken cancellationToken)
        where TQuery : IQuery<TQuery, TQueryResult>
        where TQueryResult : IQueryResult;
}
