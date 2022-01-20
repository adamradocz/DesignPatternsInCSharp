namespace DesignPatternsInCSharp.Behavioral.State.Conceptual;

public class ConcreteStateB : State
{
    public override void Handle(Context context) => context.State = new ConcreteStateC();
}
