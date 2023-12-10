namespace F1Fantasy.Infrastructure.Abstractions;

public interface ICommand<TCommand, TCommandResult>
    where TCommandResult : ICommandResult
{
}
