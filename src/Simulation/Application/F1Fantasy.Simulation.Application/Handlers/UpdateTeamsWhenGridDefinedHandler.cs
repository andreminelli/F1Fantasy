using F1Fantasy.Infrastructure.Abstractions;
using F1Fantasy.Simulation.Domain;
using Void = F1Fantasy.Infrastructure.Abstractions.Void;

namespace F1Fantasy.Simulation.Application.Handlers;

public class UpdateTeamsWhenGridDefinedHandler(ITeamRepository teamRepository) : ICommandHandler<UpdateTeamsWhenGridDefined, Void>
{
    public async Task<Void> Handle(UpdateTeamsWhenGridDefined command, CancellationToken cancellationToken)
    {
        var teams = await teamRepository.GetAll(cancellationToken);
        await Parallel.ForEachAsync(
            teams, 
            async (team, cancellationToken) => await UpdateTeamAsync(team, command.QualificationGrid, cancellationToken));

        return Void.Instance;
    }

    private async ValueTask UpdateTeamAsync(Team team, RaceGrid grid, CancellationToken cancellationToken)
    {
        team.UpdatePointsForRaceGridSet(grid);
        await teamRepository.Update(team, cancellationToken);
    }
}
