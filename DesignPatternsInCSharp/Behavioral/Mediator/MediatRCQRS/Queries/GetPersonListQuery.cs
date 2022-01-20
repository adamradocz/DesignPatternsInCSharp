using DesignPatternsInCSharp.Behavioral.Mediator.MediatRCQRS.Models;
using MediatR;

namespace DesignPatternsInCSharp.Behavioral.Mediator.MediatRCQRS.Queries;

public record GetPersonListQuery() : IRequest<List<Person>>;
