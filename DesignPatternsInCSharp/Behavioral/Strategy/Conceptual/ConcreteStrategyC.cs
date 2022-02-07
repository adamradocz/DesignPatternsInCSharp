namespace DesignPatternsInCSharp.Behavioral.Strategy.Conceptual;

/// <summary>
/// A concrete strategy
/// </summary>
public class ConcreteStrategyC : Strategy
{
    public override string Algorithm() => nameof(ConcreteStrategyC);
}
