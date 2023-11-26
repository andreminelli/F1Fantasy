using System.Diagnostics.CodeAnalysis;

namespace F1Fantasy.Domain.Simulation;

public record TeamId : IParsable<TeamId>
{
    public TeamId(string value)
    {
        Value = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Value { get; }

    public static TeamId Parse(string s, IFormatProvider? provider)
        => s;

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out TeamId result)
    {
        result = s;
        return true;
    }

    public static implicit operator TeamId(string value)
        => new TeamId(value); 
}
