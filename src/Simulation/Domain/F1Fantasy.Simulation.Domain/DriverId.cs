using System.Diagnostics.CodeAnalysis;

namespace F1Fantasy.Simulation.Domain;

public record DriverId : IParsable<DriverId>
{
    public DriverId(string value)
    {
        Value = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Value { get; }

    public static DriverId Parse(string s, IFormatProvider? provider)
        => s;

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out DriverId result)
    {
        result = s;
        return true;
    }

    public static implicit operator DriverId(string value)
        => new DriverId(value);

    public override string ToString()
        => Value;
}
