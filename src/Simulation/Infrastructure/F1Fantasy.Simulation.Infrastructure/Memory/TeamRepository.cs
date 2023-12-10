using F1Fantasy.Simulation.Domain;

namespace F1Fantasy.Simulation.Infrastructure.Memory;

public class TeamRepository : ITeamRepository
{
    private readonly Dictionary<TeamId, Team> _teams;

    public TeamRepository()
    {
        var team1 = new Team(new TeamId("1"));
        team1.AddDriver(new Driver { Id = "driver-2" });

        Team[] teams = [ team1 ];
        _teams = teams.ToDictionary(t => t.Id, t => t);
    }

    public Task<IEnumerable<Team>> GetAll(CancellationToken cancellationToken)
        => Task.FromResult(_teams.Values.AsEnumerable());

    public Task<Team> GetById(TeamId id, CancellationToken cancellationToken)
        => Task.FromResult(_teams[id]);

    public Task Update(Team team, CancellationToken cancellationToken)
    {
        _teams[team.Id] = team;
        return Task.CompletedTask;
    }
}
