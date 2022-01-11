namespace DesignPatternsInCSharp.Creational.Singleton;

// Source: https://csharpindepth.com/articles/singleton
public sealed class SingletonServiceV4
{
    private static readonly SingletonServiceV4 _instance = new();
    public static SingletonServiceV4 Instance => _instance;

    // Tell C# compiler not to mark type as beforefieldinit (https://csharpindepth.com/articles/BeforeFieldInit)
    static SingletonServiceV4()
    {
    }

    // The constructor is private to prevent instantiation except within this class.
    private SingletonServiceV4()
    {
    }
}
