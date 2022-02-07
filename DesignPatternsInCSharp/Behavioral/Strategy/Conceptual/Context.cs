namespace DesignPatternsInCSharp.Behavioral.Strategy.Conceptual;

/// <summary>
/// The context
/// </summary>
public class Context
{
    public Strategy Strategy { get; set; } = new ConcreteStrategyA();

    public string Request() => Strategy.Algorithm();
}
