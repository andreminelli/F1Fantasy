namespace F1Fantasy.Infrastructure.Abstractions;

public interface ICommandHandler<TCommand, TCommandResult>
    where TCommand : ICommand<TCommand, TCommandResult>
    where TCommandResult : ICommandResult
{
    Task<TCommandResult> Handle(TCommand command, CancellationToken cancellationToken);
}
