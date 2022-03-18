namespace DesignPatternsInCSharp.Behavioral.Chain.Conceptual;
public class ChainDebugLogger : IChainLogger
{
    private IChainLogger? _nextLogger;

    public string? LogMessage(int level, string message)
    {
        if (level > 1)
        {
            return _nextLogger?.LogMessage(level, message);
        }
        else
        {
            return $"DEBUG: {message}";
        }
    }
    public void SetNextLogger(IChainLogger nextLogger)
    {
        _nextLogger = nextLogger;
    }
}
