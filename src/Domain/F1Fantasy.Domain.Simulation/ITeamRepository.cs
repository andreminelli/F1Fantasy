namespace F1Fantasy.Domain.Simulation;

public interface ITeamRepository
{
    Task<Team> GetById(TeamId id, CancellationToken cancellationToken);
}
