namespace DesignPatternsInCSharp.Creational.Singleton;

// Source: https://csharpindepth.com/articles/singleton
public sealed class SingletonServiceV5
{
    public static SingletonServiceV5 Instance => Nested._instance;

    private class Nested
    {
        internal static readonly SingletonServiceV5 _instance = new();

        // Tell C# compiler not to mark type as beforefieldinit (https://csharpindepth.com/articles/BeforeFieldInit)
        static Nested()
        {
        }
    }

    // The constructor is private to prevent instantiation except within this class.
    private SingletonServiceV5()
    {
    }
}
