using F1Fantasy.Infrastructure.Abstractions;
using F1Fantasy.Simulation.Application;
using F1Fantasy.Simulation.Domain;
using FastEndpoints;
using System.Net;

namespace F1Fantasy.Simulation.Api.Endpoints;

public class ReceiveGridDefinedEvent : Endpoint<List<DriverId>>
{
    private readonly ICommandDispatcher _commandDispatcher;

    public ReceiveGridDefinedEvent(ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
    }

    public override void Configure()
    {
        Post("/events/gridDefined");
        //Roles(ApiRoles.EventPublisher); // TODO: Need to create a service account with role "event-publisher"
        Roles(ApiRoles.RegularUser);
    }

    public override async Task HandleAsync(List<DriverId> driverIds, CancellationToken cancellationToken)
    {
        await _commandDispatcher.Dispatch(
            new UpdateTeamsWhenGridDefined(
                new RaceGrid(driverIds)),
            cancellationToken);

        await SendAsync(null, statusCode: (int)HttpStatusCode.Accepted);
    }
}
