// See https://aka.ms/new-console-template for more information
using DesignPatternsInCSharp.Behavioral.Mediator.MediatRCQRS.Commands;
using DesignPatternsInCSharp.Behavioral.Mediator.MediatRCQRS.Data;
using DesignPatternsInCSharp.Behavioral.Mediator.MediatRCQRS.Models;
using DesignPatternsInCSharp.Behavioral.Mediator.MediatRCQRS.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, World!");

var serviceCollection = new ServiceCollection().AddMediatR(typeof(Program).Assembly).AddSingleton<DemoDataAccess>().BuildServiceProvider();
var _mediator = serviceCollection.GetRequiredService<IMediator>();

List<Person> people = await LoadAsync();
Console.WriteLine("List of people:");
for (int i = 0; i < people.Count; i++)
{
    Console.WriteLine($"#{people[i].Id}: {people[i].FirstName} {people[i].LastName}");
}

async Task<List<Person>> LoadAsync() => await _mediator.Send(new GetPersonListQuery());

async Task<Person> SaveAsync(Person person)
{
    var model = new InsertPersonCommand(person.FirstName, person.LastName);
    return await _mediator.Send(model);
}
Console.WriteLine("Now saving a new person: Alter Ego");
Thread.Sleep(2000);
await SaveAsync(new Person() { FirstName = "Alter", LastName = "Ego" });


Person person = await GetById(3);
async Task<Person> GetById(int id) => await _mediator.Send(new GetPersonByIdQuery(id));

Console.WriteLine($"Person with id #3: {person.FirstName} {person.LastName}");
