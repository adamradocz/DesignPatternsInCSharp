namespace DesignPatternsInCSharp.Creational.Prototype;

internal interface IPrototype<T> where T : class
{
    T ShallowClone();
    T DeepClone();
}
