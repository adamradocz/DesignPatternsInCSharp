namespace Singleton.RealWorld;

/// <summary>
/// Lazy and thread safe implementation.
/// </summary>
/// <remarks>
/// The class is marked sealed to prevent derivation.
/// </remarks>
public sealed class SingletonService
{
    // Laziness and thread safety
    private static readonly Lazy<SingletonService> _instance = new(() => new SingletonService());
    public static SingletonService Instance => _instance.Value;
    public int Counter { get; private set; } = 0;

    // The constructor is private to prevent instantiation.
    private SingletonService()
    {
        Counter++;
    }
}
