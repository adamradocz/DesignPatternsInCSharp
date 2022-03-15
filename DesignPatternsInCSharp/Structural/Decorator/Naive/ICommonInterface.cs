namespace DesignPatternsInCSharp.Structural.Decorator.Naive;

public interface ICommonInterface
{
    public string? CurrentData { get; }

    public void DoStuff(string param);
}
