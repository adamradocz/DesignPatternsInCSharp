namespace DesignPatternsInCSharp.Creational.Singleton;

// Source: https://csharpindepth.com/articles/singleton
public sealed class SingletonServiceV6
{
    // Laziness and thread safety
    private static readonly Lazy<SingletonServiceV6> _instance = new(() => new SingletonServiceV6());
    public static SingletonServiceV6 Instance => _instance.Value;

    // The constructor is private to prevent instantiation except within this class.
    private SingletonServiceV6()
    {
    }
}
