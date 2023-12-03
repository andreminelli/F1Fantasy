namespace F1Fantasy.Infrastructure.Abstractions;

public interface ICommandDispatcher
{
    Task<TCommandResult> Dispatch<TCommandResult>(ICommand<TCommandResult> command, CancellationToken cancellationToken);
}