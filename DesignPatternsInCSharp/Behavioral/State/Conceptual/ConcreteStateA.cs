namespace DesignPatternsInCSharp.Behavioral.State.Conceptual;

public class ConcreteStateA : State
{
    public override void Handle(Context context)
    {
        context.State = new ConcreteStateB();
    }
}
