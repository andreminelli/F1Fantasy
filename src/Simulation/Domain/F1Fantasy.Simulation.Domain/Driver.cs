namespace F1Fantasy.Simulation.Domain;

public class Driver : IEquatable<Driver>
{
    public DriverId Id { get; init; }

    public bool Equals(Driver? other)
        => Id is not null && Id.Equals(other?.Id);
}
