namespace DesignPatternsInCSharp.Creational.Factories.Factory.GenericTypeFactory;

public interface IFactoryV2WithId<T> where T : class
{
    T CreateObjectWithId(int id);
}
