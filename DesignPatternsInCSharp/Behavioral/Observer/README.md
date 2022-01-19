# Observable Pattern

![Observable UML Diagram](Observable.svg)

GoF Definition: Define a one-to-many dependency between objects so that when one object changes state, all its dependents are notified and updated automatically.

Observable(subject) contains a list of observers to notify of any change in it’s state, so it should provide methods using which observers can register and unregister themselves.
Observable(subject) also contain a method to notify all the observers of any change and either it can send the update while notifying the observer or it can provide another method to get the update.
Observer should have a method to set the object to watch and another method that will be used by Subject to notify them of any updates.

## Sources

- https://refactoring.guru/design-patterns/observer
