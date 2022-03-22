namespace DesignPatternsInCSharp.Behavioral.Chain.Conceptual;
public interface IChainLogger
{
    public string? LogMessage(ChainLogLevel level, in string message);

    public void SetNextLogger(in IChainLogger nextLogger);
}
