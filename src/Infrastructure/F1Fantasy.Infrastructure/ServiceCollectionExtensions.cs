using F1Fantasy.Simulation.Domain;
using F1Fantasy.Simulation.Infrastructure.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace F1Fantasy.Simulation.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSimulationInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<ITeamRepository, TeamRepository>();
        return services;
    }
}
