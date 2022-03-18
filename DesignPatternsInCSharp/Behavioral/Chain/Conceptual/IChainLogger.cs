namespace DesignPatternsInCSharp.Behavioral.Chain.Conceptual;
public interface IChainLogger
{
    public string? LogMessage(int level, string message);

    public void SetNextLogger(IChainLogger nextLogger);
}
