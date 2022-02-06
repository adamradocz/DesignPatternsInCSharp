using DesignPatternsInCSharp.Behavioral.Mediator.MediatRCQRS.Models;
using DesignPatternsInCSharp.Behavioral.Mediator.MediatRCQRS.Queries;
using MediatR;
using IMediator = MediatR.IMediator;

namespace DesignPatternsInCSharp.Behavioral.Mediator.MediatRCQRS.Handlers;

public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery, Person>
{
    private readonly IMediator _mediator;

    public GetPersonByIdHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<Person> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {
        var results = await _mediator.Send(new GetPersonListQuery(), cancellationToken);

        var output = results.FirstOrDefault(x => x.Id == request.Id);

        return output;
    }
}

