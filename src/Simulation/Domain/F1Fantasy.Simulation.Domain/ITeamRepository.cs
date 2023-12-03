namespace F1Fantasy.Simulation.Domain;

public interface ITeamRepository
{
    Task<Team> GetById(TeamId id, CancellationToken cancellationToken);
}
