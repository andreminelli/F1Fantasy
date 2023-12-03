using F1Fantasy.Infrastructure.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace F1Fantasy.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IQueryDispatcher, QueryDispatcher>();
        return services;
    }

    public static IServiceCollection AddApplicationHandlers<T>(this IServiceCollection services)
    {
        services.Scan(selector =>
        {
            selector.FromAssembliesOf(typeof(T))
                    .AddClasses(filter =>
                    {
                        filter.AssignableTo(typeof(IQueryHandler<,>));
                    })
                    .AsImplementedInterfaces()
                    .WithSingletonLifetime();
        });
        return services;
    }
}
