namespace DesignPatternsInCSharp.Structural.Decorator.Naive;

public class BaseDecorator : ICommonInterface
{
    private ICommonInterface _wrappee;

    public string? CurrentData => _wrappee?.CurrentData;

    public BaseDecorator(ICommonInterface commonInterface)
    {
        _wrappee = commonInterface;
    }

    public virtual void DoStuff(string param) => _wrappee.DoStuff(param);
}
