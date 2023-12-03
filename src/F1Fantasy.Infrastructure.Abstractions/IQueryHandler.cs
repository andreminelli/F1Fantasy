namespace F1Fantasy.Infrastructure.Abstractions;

public interface IQueryHandler<TQuery, TQueryResult>
    where TQuery : IQuery<TQuery, TQueryResult>
    where TQueryResult : IQueryResult
{
    Task<TQueryResult> Handle(TQuery query, CancellationToken cancellationToken);
}
