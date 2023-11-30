using F1Fantasy.Infrastructure.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace F1Fantasy.Infrastructure;

public class QueryDispatcher(IServiceProvider serviceProvider)
    : IQueryDispatcher
{
    public async Task<TQueryResult> Dispatch<TQuery, TQueryResult>(TQuery query, CancellationToken cancellationToken)
        where TQuery : IQuery<TQueryResult>
        where TQueryResult : IQueryResult
    {
        var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TQueryResult));
        var handler = (IQueryHandler<TQuery, TQueryResult>) serviceProvider.GetRequiredService(handlerType);
        return await handler.Handle(query, cancellationToken);
    }
}
