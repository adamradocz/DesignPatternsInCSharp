namespace DesignPatternsInCSharp.Behavioral.Chain.Conceptual;
public class ChainWarningLogger : IChainLogger
{
    private IChainLogger? _nextLogger;

    public string? LogMessage(ChainLogLevel level, in string message)
    {
        if (level > ChainLogLevel.WARNING)
        {
            if (_nextLogger == null)
            {
                return "Next logger in the chain is not set, and the current one cannot handle the request";
            }
            return _nextLogger?.LogMessage(level, message);
        }
        else
        {
            return $"WARNING: {message}";
        }
    }

    public void SetNextLogger(in IChainLogger nextLogger)
    {
        _nextLogger = nextLogger;
    }
}
