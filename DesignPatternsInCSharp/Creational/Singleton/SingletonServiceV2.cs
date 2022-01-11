namespace DesignPatternsInCSharp.Creational.Singleton;

// BAD CODE
// Source: https://csharpindepth.com/articles/singleton
public sealed class SingletonServiceV2
{
    private static SingletonServiceV2? _instance;
    private static readonly object _padlock = new();

    public static SingletonServiceV2 Instance
    {
        get
        {
            // This lock is used on *every* reference to Singleton.
            lock (_padlock)
            {
                if (_instance == null)
                {
                    _instance = new SingletonServiceV2();
                }

                return _instance;
            }
        }
    }

    // The constructor is private to prevent instantiation except within this class.
    private SingletonServiceV2()
    {
    }
}
