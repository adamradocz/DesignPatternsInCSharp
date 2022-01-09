namespace Singleton.Conceptual;

/// <summary>
/// This implementation is NOT thread safe.
/// </summary>
public class SingletonService
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
}
