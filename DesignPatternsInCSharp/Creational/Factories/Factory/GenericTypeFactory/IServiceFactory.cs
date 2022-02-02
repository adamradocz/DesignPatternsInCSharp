namespace DesignPatternsInCSharp.Creational.Factories.Factory.GenericTypeFactory;

public interface IServiceFactory<TService>
{
    TService CreateService();
    TService CreateServiceWithParam(params object[] args);
}
