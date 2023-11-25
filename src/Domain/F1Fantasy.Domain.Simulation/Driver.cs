namespace F1Fantasy.Domain.Simulation;

public class Driver
{
    public DriverId Id { get; init; }
}

public record DriverId(string Value);
