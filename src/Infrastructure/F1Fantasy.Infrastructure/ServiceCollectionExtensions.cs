using F1Fantasy.Domain.Simulation;
using F1Fantasy.Infrastructure.Abstractions;
using F1Fantasy.Infrastructure.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace F1Fantasy.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IQueryDispatcher, QueryDispatcher>();

        services.AddSingleton<ITeamRepository, TeamRepository>();
    }

    public static void AddApplicationHandlers<T>(this IServiceCollection services)
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
    }
}
