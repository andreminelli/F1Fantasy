using F1Fantasy.Infrastructure.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace F1Fantasy.Infrastructure;

public class QueryDispatcher(IServiceProvider serviceProvider)
    : IQueryDispatcher
{
    public async Task<TQueryResult> Dispatch<TQueryResult>(IQuery<TQueryResult> query, CancellationToken cancellationToken)
    {
        var handler = serviceProvider.GetRequiredService<IQueryHandler<IQuery<TQueryResult>, TQueryResult>>();
        return await handler.Handle(query, cancellationToken);
    }
}
