using DesignPatternsInCSharp.Behavioral.Mediator.MediatRCQRS.Commands;
using DesignPatternsInCSharp.Behavioral.Mediator.MediatRCQRS.Data;
using DesignPatternsInCSharp.Behavioral.Mediator.MediatRCQRS.Models;
using MediatR;

namespace DesignPatternsInCSharp.Behavioral.Mediator.MediatRCQRS.Handlers;

public class InsertPersonHandler : IRequestHandler<InsertPersonCommand, Person>
{
    private readonly DemoDataAccess _data;

    public InsertPersonHandler(DemoDataAccess data) => _data = data;

    public Task<Person> Handle(InsertPersonCommand request, CancellationToken cancellationToken) => Task.FromResult(_data.InsertPerson(request.FirstName, request.LastName));
}
