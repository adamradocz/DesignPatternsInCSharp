using DesignPatternsInCSharp.Behavioral.Mediator.MediatRCQRS.Data;
using DesignPatternsInCSharp.Behavioral.Mediator.MediatRCQRS.Models;
using DesignPatternsInCSharp.Behavioral.Mediator.MediatRCQRS.Queries;
using MediatR;

namespace DesignPatternsInCSharp.Behavioral.Mediator.MediatRCQRS.Handlers;

public class GetPersonListHandler : IRequestHandler<GetPersonListQuery, List<Person>>
{
    private readonly DemoDataAccess _data;

    public GetPersonListHandler(DemoDataAccess data) => _data = data;

    public Task<List<Person>> Handle(GetPersonListQuery request, CancellationToken cancellationToken) => Task.FromResult(_data.GetPeople());
}