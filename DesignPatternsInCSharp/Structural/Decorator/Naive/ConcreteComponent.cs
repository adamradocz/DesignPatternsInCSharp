namespace DesignPatternsInCSharp.Structural.Decorator.Naive;

public class ConcreteComponent : ICommonInterface
{
    private string? _currentData;
    public string? CurrentData => _currentData;

    public void DoStuff(string param) => _currentData += param;
}
