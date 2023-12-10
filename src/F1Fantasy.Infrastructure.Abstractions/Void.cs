namespace F1Fantasy.Infrastructure.Abstractions;

public sealed class Void : ICommandResult
{
    public static Void Instance { get; } = new Void();

    private Void() { }
}
