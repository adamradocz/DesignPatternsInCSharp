namespace DesignPatternsInCSharp.Behavioral.Chain.Conceptual;
public class ChainInfoLogger : IChainLogger
{
    private IChainLogger? _nextLogger;

    public string? LogMessage(ChainLogLevel level, in string message)
    {
        if (level > ChainLogLevel.INFO)
        {
            if (_nextLogger == null)
            {
                return "Next logger in the chain is not set, and the current one cannot handle the request";
            }
            return _nextLogger?.LogMessage(level, message);
        }
        else
        {
            return $"INFO: {message}";
        }
    }

    public void SetNextLogger(in IChainLogger nextLogger)
    {
        _nextLogger = nextLogger;
    }
}
