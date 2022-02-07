# Strategy Pattern

![State UML Diagram](strategy.svg)

GoF Definition: Defines a family of algorithms, encapsulates each one, and maked them interchangeable. Strategy lets the algorithm vary independently from clients that use it.

## Elements of the Strategy Pattern

- Strategy: Declares an abstract method common to all supported algorithms. Context uses this method to call the algorithm defined by a concrete strategy
- Concrete strategy: Implements the abstract algorithm.
- Context: Maintains an instance of a concrete strategy,

## Sources

- https://www.dofactory.com/net/strategy-design-pattern
