namespace DesignPatternsInCSharp.Behavioral.Strategy.Conceptual;

/// <summary>
/// A concrete strategy
/// </summary>
public class ConcreteStrategyA : Strategy
{
    public override string Algorithm() => nameof(ConcreteStrategyA);
}
