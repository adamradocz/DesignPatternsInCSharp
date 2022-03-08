namespace DesignPatternsInCSharp.Structural.Decorator.Naive;

public class ConcreteDecorator : BaseDecorator
{
    public ConcreteDecorator(ICommonInterface commonInterface) : base(commonInterface)
    {

    }

    public override void DoStuff(string param)
    {
        string newParam = param + " decorated with " +nameof(ConcreteDecorator);
        base.DoStuff(newParam);
    }
}
