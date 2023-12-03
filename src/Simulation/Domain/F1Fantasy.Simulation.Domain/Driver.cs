namespace F1Fantasy.Simulation.Domain;

public class Driver
{
    public DriverId Id { get; init; }
}

public record DriverId(string Value);
