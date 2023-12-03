namespace F1Fantasy.Simulation.Domain;

public class RaceGrid(IList<Driver> grid)
{
    public int GetPosition(Driver driver)
        => grid.IndexOf(driver) switch
        {
            < 0 => 0,
            int value => value + 1
        };
}