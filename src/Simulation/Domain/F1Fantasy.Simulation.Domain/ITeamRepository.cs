namespace F1Fantasy.Simulation.Domain;

public interface ITeamRepository
{
    Task<IEnumerable<Team>> GetAll(CancellationToken cancellationToken);
    Task<Team> GetById(TeamId id, CancellationToken cancellationToken);

    Task Update(Team team, CancellationToken cancellationToken);
}
