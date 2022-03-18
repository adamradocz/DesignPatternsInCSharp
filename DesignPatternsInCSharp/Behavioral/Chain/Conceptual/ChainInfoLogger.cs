namespace DesignPatternsInCSharp.Behavioral.Chain.Conceptual;
public class ChainInfoLogger : IChainLogger
{
    private IChainLogger? _nextLogger;

    public string? LogMessage(int level, string message)
    {
        if (level > 2)
        {
            return _nextLogger?.LogMessage(level, message);
        }
        else
        {
            return $"INFO: {message}";
        }
    }

    public void SetNextLogger(IChainLogger nextLogger)
    {
        _nextLogger = nextLogger;
    }
}
