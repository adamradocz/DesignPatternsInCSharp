namespace DesignPatternsInCSharp.Creational.Factories.Factory.GenericTypeFactory;

public interface IFactory<T>
{
    T CreateObject();
    T CreateObjectWithParam(params object[] args);
}
