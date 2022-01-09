namespace Singleton.RealWorld;

/// <summary>
/// Everithing is taken care of by the Dependency Injection Container.
/// </summary>
public class SingletonServiceV2
{
    public int Counter { get; private set; } = 0;

    public SingletonServiceV2()
    {
        Counter++;
    }
}
