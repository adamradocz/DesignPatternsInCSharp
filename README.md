# Design patterns in C#
The ultimate design pattern collection in C#

## Requirements

- [.NET 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- Any .NET 6 capable IDE:
  - [Visual Studio 2022](https://www.visualstudio.com/downloads/) on Windows.
  - [Visual Studio Code](https://code.visualstudio.com/) on any OS.
  - [Rider](https://www.jetbrains.com/rider/) on any OS.

## Gang of Four (GoF) patterns

### Creational patterns

Creational patterns are ones that create objects, rather than having to instantiate objects directly. This gives the program more flexibility in deciding which objects need to be created for a given case.

- [Abstract Factory](DesignPatternsInCSharp/Creational/AbstractFactory/README.md) groups object factories that have a common theme.
- [Builder](DesignPatternsInCSharp/Creational/Builder/README.md) constructs complex objects by separating construction and representation.
- [Factory method](DesignPatternsInCSharp/Creational/Factories/FactoryMethod/README.md) creates objects without specifying the exact class to create.
- [Prototype](DesignPatternsInCSharp/Creational/Prototype/README.md) creates objects by cloning an existing object.
- [Singleton](Creational/Singleton/README.md) restricts object creation for a class to only one instance.

### Structural patterns

These concern class and object composition. They use inheritance to compose interfaces and define ways to compose objects to obtain new functionality.

- [Adapter](DesignPatternsInCSharp/Structural/Adapter/README.md) allows classes with incompatible interfaces to work together by wrapping its own interface around that of an already existing class.
- Bridge decouples an abstraction from its implementation so that the two can vary independently.
- Composite composes zero-or-more similar objects so that they can be manipulated as one object.
- Decorator dynamically adds/overrides behaviour in an existing method of an object.
- Facade provides a simplified interface to a large body of code.
- [Flyweight](DesignPatternsInCSharp/Structural/Flyweight/README.md) reduces the cost of creating and manipulating a large number of similar objects.
- Proxy provides a placeholder for another object to control access, reduce cost, and reduce complexity.

### Behavioral patterns

Most of these design patterns are specifically concerned with communication between objects.

- Chain of responsibility delegates commands to a chain of processing objects.
- Command creates objects that encapsulate actions and parameters.
- Interpreter implements a specialized language.
- Iterator accesses the elements of an object sequentially without exposing its underlying representation.
- [Mediator](DesignPatternsInCSharp/Behavioral/Mediator) allows loose coupling between classes by being the only class that has detailed knowledge of their methods.
- Memento provides the ability to restore an object to its previous state (undo).
- [Observer](DesignPatternsInCSharp/Behavioral/Observer/README.md) is a publish/subscribe pattern, which allows a number of observer objects to see an event.
- [State](DesignPatternsInCSharp/Behavioral/State/README.md) allows an object to alter its behavior when its internal state changes.
- [Strategy](DesignPatternsInCSharp/Behavioral/Strategy/README.md) allows one of a family of algorithms to be selected on-the-fly at runtime.
- Template method defines the skeleton of an algorithm as an abstract class, allowing its subclasses to provide concrete behavior.
- Visitor separates an algorithm from an object structure by moving the hierarchy of methods into one object.

## Other frequently used patterns

- [Factory](DesignPatternsInCSharp/Creational/Factories/Factory/README.md).
- Repository.
- Unit of work is an object-relational behavioral pattern.

## Game programming patterns in Unity

TODO
