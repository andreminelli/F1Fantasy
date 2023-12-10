namespace F1Fantasy.Infrastructure.Abstractions;

public interface ICommandDispatcher
{
    Task<TCommandResult> Dispatch<TCommand, TCommandResult>(ICommand<TCommand, TCommandResult> command, CancellationToken cancellationToken)
        where TCommand : ICommand<TCommand, TCommandResult>
        where TCommandResult : ICommandResult;
}