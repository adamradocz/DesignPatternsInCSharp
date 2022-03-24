namespace DesignPatternsInCSharp.Creational.Factories.Factory.GenericTypeFactory;

public interface IFactory<T> where T : class
{
    T CreateObject();
    T CreateObjectWithParam(params object[] args);
}
