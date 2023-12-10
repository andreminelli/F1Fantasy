using F1Fantasy.Infrastructure.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace F1Fantasy.Infrastructure;

public class CommandDispatcher(IServiceProvider serviceProvider)
    : ICommandDispatcher
{
    public async Task<TCommandResult> Dispatch<TCommand, TCommandResult>(ICommand<TCommand, TCommandResult> command, CancellationToken cancellationToken)
        where TCommand : ICommand<TCommand, TCommandResult>
        where TCommandResult : ICommandResult
    {
        var handlerType = typeof(ICommandHandler<,>).MakeGenericType(command.GetType(), typeof(TCommandResult));
        var handler = (ICommandHandler<TCommand, TCommandResult>)serviceProvider.GetRequiredService(handlerType);
        var commandCast = (TCommand)command;
        return await handler.Handle(commandCast, cancellationToken);
    }
}
