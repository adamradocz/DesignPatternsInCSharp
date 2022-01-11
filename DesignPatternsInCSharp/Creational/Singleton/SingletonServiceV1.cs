namespace DesignPatternsInCSharp.Creational.Singleton;

// BAD CODE
// Source: https://csharpindepth.com/articles/singleton
public sealed class SingletonServiceV1
{
    private static SingletonServiceV1? _instance;

    public static SingletonServiceV1 Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new SingletonServiceV1();
            }

            return _instance;
        }
    }

    // The constructor is private to prevent instantiation except within this class.
    private SingletonServiceV1()
    {
    }
}
