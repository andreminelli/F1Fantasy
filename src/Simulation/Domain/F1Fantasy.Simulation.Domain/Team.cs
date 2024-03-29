﻿using F1Fantasy.Domain.SharedKernel;

namespace F1Fantasy.Simulation.Domain;

public class Team : Entity<TeamId>
{
    public Team(TeamId id)
    {
        Id = id;
        Drivers = new List<Driver>();
    }

    public double Points { get; protected set; }

    protected IList<Driver> Drivers { get; }

    public void AddDriver(Driver driver)
        => Drivers.Add(driver);

    public void UpdatePointsForRaceGridSet(RaceGrid raceGrid)
    {
        Points += GetPointsForDriversPositions(raceGrid);
    }

    public void UpdatePointsForRaceGridLap(RaceGrid raceGrid)
    {
        Points += GetPointsForDriversPositions(raceGrid) * 0.02;
    }

    protected virtual int GetPointsForDriverPlace(int place)
        => place switch
        {
            1 => 30,
            2 => 25,
            3 => 20,
            <= 20 => 20 - place,
            _ => 0
        };

    private int GetPointsForDriversPositions(RaceGrid raceGrid)
    {
        var points = 0;
        foreach (var driver in Drivers)
        {
            points += GetPointsForDriverPlace(
                        raceGrid.GetPosition(driver.Id));
        }

        return points;
    }
}
