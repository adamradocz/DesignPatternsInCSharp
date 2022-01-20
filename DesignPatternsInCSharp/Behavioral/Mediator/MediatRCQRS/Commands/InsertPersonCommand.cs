using DesignPatternsInCSharp.Behavioral.Mediator.MediatRCQRS.Models;
using MediatR;

namespace DesignPatternsInCSharp.Behavioral.Mediator.MediatRCQRS.Commands;

public record InsertPersonCommand(string FirstName, string LastName) : IRequest<Person>;

//public class InsertPersonCommandClass : IRequest<PersonModel>
//{
//    public string FirstName { get; set; }
//    public string LastName { get; set; }

//    public InsertPersonCommandClass(string firstName, string lastName)
//    {
//        FirstName = firstName;
//        LastName = lastName;
//    }
//}