using F1Fantasy.Infrastructure.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace F1Fantasy.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IQueryDispatcher, QueryDispatcher>();
        services.AddTransient<ICommandDispatcher, CommandDispatcher>();
        return services;
    }

    public static IServiceCollection AddApplicationHandlers<T>(this IServiceCollection services)
    {
        services.Scan(selector =>
        {
            selector.FromAssembliesOf(typeof(T))
                    .AddClasses(filter =>
                    {
                        filter.AssignableToAny(typeof(IQueryHandler<,>), typeof(ICommandHandler<,>));
                    })
                    .AsImplementedInterfaces()
                    .WithSingletonLifetime();
        });
        return services;
    }
}
