namespace Singleton.Conceptual;

/// <summary>
/// This implementation is NOT thread safe.
/// </summary>
/// <remarks>
/// The class is marked sealed to prevent derivation.
/// </remarks>
public sealed class SingletonService
{
    private static SingletonService? _instance;

    public static SingletonService Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new SingletonService();
            }

            return _instance;
        }
    }
    
    // The constructor is private to prevent instantiation.
    private SingletonService()
    {
    }
}
