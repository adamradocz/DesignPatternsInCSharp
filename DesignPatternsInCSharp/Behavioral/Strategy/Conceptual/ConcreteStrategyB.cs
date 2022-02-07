namespace DesignPatternsInCSharp.Behavioral.Strategy.Conceptual;

/// <summary>
/// A concrete strategy
/// </summary>
public class ConcreteStrategyB : Strategy
{
    public override string Algorithm() => nameof(ConcreteStrategyB);
}

