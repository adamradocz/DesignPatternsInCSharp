# State Pattern

GoF Definition: Allows an object to alter its behavior when its internal state changes.

Simple explanation: Allows an object to change what it does based on its current state.

## Elements of the State Pattern

- Context: Maintains an instance of a concrete state as the current state. This is used by the clients.
- Abstract State: Defines an interface which encapsulates all state-specific behaviours
- Concrate State: Implements behaviours specific to a particular state of context. State classes should be responsible for transitioning state.

## Approch

- List of possible states.
- The conditions for transitioning between those states.
- The state its in when initialized, or its initial state.

# State pattern and Workflow Frameworks

- [Stateless](https://github.com/dotnet-state-machine/stateless) for creating state machines and lightweight state machine-based workflows.
- [ELSA](https://elsa-workflows.github.io/elsa-core/) for creating workflows.

## Sources

- https://www.dofactory.com/net/state-design-pattern
