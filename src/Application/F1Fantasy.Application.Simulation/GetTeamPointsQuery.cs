using F1Fantasy.Domain.Simulation;
using F1Fantasy.Infrastructure.Abstractions;

namespace F1Fantasy.Application.Simulation;

public record GetTeamPointsQuery(TeamId TeamId) : IQuery<GetTeamPointsQuery, TeamPointsQueryResult>;

public record TeamPointsQueryResult(TeamId TeamId, double Points) : IQueryResult;