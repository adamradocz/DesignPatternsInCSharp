namespace DesignPatternsInCSharp.Behavioral.State.Conceptual;

public class Context
{
    public State State { get; set; }

    public Context(State state)
    {
        State = state ?? throw new ArgumentNullException(nameof(state));
    }

    public void Request() => State.Handle(this);
}
