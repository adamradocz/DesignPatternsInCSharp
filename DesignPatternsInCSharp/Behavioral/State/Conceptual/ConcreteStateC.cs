namespace DesignPatternsInCSharp.Behavioral.State.Conceptual;

public class ConcreteStateC : State
{
    public override void Handle(Context context)
    {
        context.State = new ConcreteStateA();
    }
}
