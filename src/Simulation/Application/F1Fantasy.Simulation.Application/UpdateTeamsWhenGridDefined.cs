using F1Fantasy.Infrastructure.Abstractions;
using F1Fantasy.Simulation.Domain;
using Void = F1Fantasy.Infrastructure.Abstractions.Void;

namespace F1Fantasy.Simulation.Application;

public record UpdateTeamsWhenGridDefined(RaceGrid QualificationGrid) : ICommand<UpdateTeamsWhenGridDefined, Void>;

