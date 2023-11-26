using F1Fantasy.Domain.Simulation;
using F1Fantasy.Infrastructure.Abstractions;

namespace F1Fantasy.Application.Simulation;

public record GetTeamPointsQuery(TeamId Id) : IQuery<GetTeamPointsQueryResult>;

public record GetTeamPointsQueryResult(TeamId Id, double Points);