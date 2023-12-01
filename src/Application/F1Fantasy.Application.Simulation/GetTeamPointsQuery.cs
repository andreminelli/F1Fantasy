using F1Fantasy.Domain.Simulation;
using F1Fantasy.Infrastructure.Abstractions;

namespace F1Fantasy.Application.Simulation;

public record GetTeamPointsQuery(TeamId Id) : IQuery<GetTeamPointsQuery, TeamPointsQueryResult>;

public record TeamPointsQueryResult(TeamId Id, double Points) : IQueryResult;