namespace DesignPatternsInCSharp.Creational.Factories.Factory.Lazy;

public interface ILazyFactory<T>
{
    T Value { get; }
}
