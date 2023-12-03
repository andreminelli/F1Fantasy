namespace F1Fantasy.Infrastructure.Abstractions;

public interface IQuery<TQuery, TQueryResult> 
    where TQueryResult : IQueryResult
{
}
