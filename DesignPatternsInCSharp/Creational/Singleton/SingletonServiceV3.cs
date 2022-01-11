namespace DesignPatternsInCSharp.Creational.Singleton;

// BAD CODE
// Source: https://csharpindepth.com/articles/singleton
public sealed class SingletonServiceV3
{
    private static SingletonServiceV3? _instance;
    private static readonly object _padlock = new();

    public static SingletonServiceV3 Instance
    {
        get
        {
            // Only get a lock if the instance is null.
            if (_instance == null)
            {
                lock (_padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonServiceV3();
                    }
                }
            }

            return _instance;
        }
    }

    // The constructor is private to prevent instantiation except within this class.
    private SingletonServiceV3()
    {
    }
}
