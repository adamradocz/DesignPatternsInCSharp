namespace DesignPatternsInCSharp.Creational.Factories.Factory.GenericTypeFactory;

public interface IFactoryV2<T> where T : class
{
    T CreateObject();
}
