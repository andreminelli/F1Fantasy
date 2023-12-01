using F1Fantasy.Infrastructure.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace F1Fantasy.Infrastructure;

public class QueryDispatcher(IServiceProvider serviceProvider)
    : IQueryDispatcher
{
    public async Task<TQueryResult> Dispatch<TQuery, TQueryResult>(IQuery<TQuery, TQueryResult> query, CancellationToken cancellationToken)
        where TQuery : IQuery<TQuery, TQueryResult>
        where TQueryResult : IQueryResult
    {
        var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TQueryResult));
        var handler = (IQueryHandler<TQuery, TQueryResult>) serviceProvider.GetRequiredService(handlerType);
        var queryCast = (TQuery) query;
        return await handler.Handle(queryCast, cancellationToken);
    }
}
