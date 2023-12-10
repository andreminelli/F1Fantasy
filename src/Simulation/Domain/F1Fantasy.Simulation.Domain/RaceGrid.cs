using System.Collections.ObjectModel;

namespace F1Fantasy.Simulation.Domain;

public class RaceGrid(IList<DriverId> grid /*, Race or something like that must be added */)
{
    public ReadOnlyCollection<DriverId> Grid => grid.AsReadOnly();

    /// <summary>
    /// Returns the driver position in a grid
    /// </summary>
    /// <param name="driver"></param>
    /// <returns>Number referencing the driver position (first driver in the grid will get 1,
    /// second will get 2, and so on)</returns>
    public int GetPosition(DriverId driver)
        => Grid.IndexOf(driver) switch
        {
            < 0 => 0,
            int value => value + 1
        };
}