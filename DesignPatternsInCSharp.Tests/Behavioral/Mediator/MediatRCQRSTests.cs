using DesignPatternsInCSharp.Behavioral.Mediator.MediatRCQRS.Commands;
using DesignPatternsInCSharp.Behavioral.Mediator.MediatRCQRS.Data;
using DesignPatternsInCSharp.Behavioral.Mediator.MediatRCQRS.Handlers;
using DesignPatternsInCSharp.Behavioral.Mediator.MediatRCQRS.Models;
using DesignPatternsInCSharp.Behavioral.Mediator.MediatRCQRS.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesignPatternsInCSharp.Tests.Behavioral.Mediator;

[TestClass]
public class MediatRCQRSTests
{
    private readonly IMediator _mediator;

    public MediatRCQRSTests()
    {
        var serviceCollection = new ServiceCollection().AddMediatR(typeof(InsertPersonHandler).Assembly).AddSingleton<DemoDataAccess>().BuildServiceProvider();
        _mediator = serviceCollection.GetRequiredService<IMediator>();
    }

    [TestMethod]
    public async Task GetPersonListQuery_LoadPeople_PeopleLoaded()
    {
        List<Person> people = await _mediator.Send(new GetPersonListQuery());
        Assert.AreEqual(2, people.Count);
    }

    [TestMethod]
    public async Task InsertPersonCommand_InsterAPerson_PersonSaved()
    {
        List<Person> people = await _mediator.Send(new GetPersonListQuery());
        Assert.AreEqual(2, people.Count);

        var newPerson = new InsertPersonCommand("Alter", "Ego");
        _ = await _mediator.Send(newPerson);

        people = await _mediator.Send(new GetPersonListQuery());
        Assert.AreEqual(3, people.Count);
    }

    [TestMethod]
    public async Task GetPersonByIdQuery_GetAPersonById_PersonGetByTheSpecificId()
    {
        Person person = await _mediator.Send(new GetPersonByIdQuery(1));

        Assert.AreEqual("David", person.FirstName);
        Assert.AreEqual("Fowler", person.LastName);
    }
}
