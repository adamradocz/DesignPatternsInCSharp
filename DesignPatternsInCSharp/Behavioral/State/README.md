# State Pattern

![State UML Diagram](state.svg)

GoF Definition: Allows an object to alter its behavior when its internal state changes.

Simple explanation: Allows an object to change what it does based on its current state.

## Elements of the State Pattern

- Context: Maintains an instance of a concrete state as the current state. This is used by the clients.
- Abstract State: Defines an interface which encapsulates all state-specific behaviours
- Concrate State: Implements behaviours specific to a particular state of context. State classes should be responsible for transitioning state.

## Approach

- List of possible states.
- The conditions for transitioning between those states.
- The state its in when initialized, or its initial state.

## Benchmark

``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
11th Gen Intel Core i7-11800H 2.30GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.101
  [Host]     : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT


```
|    Method |       Mean |     Error |      StdDev | Ratio | RatioSD | Code Size |  Gen 0 |  Gen 1 | Allocated |
|---------- |-----------:|----------:|------------:|------:|--------:|----------:|-------:|-------:|----------:|
|     Naive |   100.5 ns |   3.20 ns |     9.45 ns |  1.00 |    0.00 |   2,266 B | 0.0159 |      - |     200 B |
| Stateless | 7,857.2 ns | 349.80 ns | 1,031.39 ns | 78.80 |   12.58 |   6,765 B | 1.3428 | 0.0305 |  16,912 B |


# State pattern and Workflow Frameworks

- [Stateless](https://github.com/dotnet-state-machine/stateless) for creating state machines and lightweight state machine-based workflows.
- [ELSA](https://elsa-workflows.github.io/elsa-core/) for creating workflows.

## Sources

- https://www.dofactory.com/net/state-design-pattern
