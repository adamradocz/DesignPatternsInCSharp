using DesignPatternsInCSharp.Behavioral.Mediator.MediatRCQRS.Models;
using MediatR;

namespace DesignPatternsInCSharp.Behavioral.Mediator.MediatRCQRS.Queries;

public record GetPersonByIdQuery(int Id) : IRequest<Person>;
