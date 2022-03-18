namespace DesignPatternsInCSharp.Behavioral.Chain.Conceptual;
public class ChainWarningLogger : IChainLogger
{
    private IChainLogger? _nextLogger;

    public string? LogMessage(int level, string message)
    {
        if (level > 3)
        {
            return _nextLogger?.LogMessage(level, message);
        }
        else
        {
            return $"WARNING: {message}";
        }
    }

    public void SetNextLogger(IChainLogger nextLogger)
    {
        _nextLogger = nextLogger;
    }
}
