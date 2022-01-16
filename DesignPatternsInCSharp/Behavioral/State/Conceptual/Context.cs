namespace DesignPatternsInCSharp.Behavioral.State.Conceptual;

public class Context
{
    private State _state;

    public Context(State state)
    {
        _state = state ?? throw new ArgumentNullException(nameof(state));
    }

    public void SetState(State state)
    {
        _state = state;
        state.Handle(this);
    }
}
