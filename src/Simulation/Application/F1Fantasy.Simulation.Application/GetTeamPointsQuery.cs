using F1Fantasy.Infrastructure.Abstractions;
using F1Fantasy.Simulation.Domain;

namespace F1Fantasy.Simulation.Application;

public record GetTeamPointsQuery(TeamId TeamId) : IQuery<GetTeamPointsQuery, TeamPointsQueryResult>;

public record TeamPointsQueryResult(TeamId TeamId, double Points) : IQueryResult;