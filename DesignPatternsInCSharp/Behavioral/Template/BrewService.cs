namespace DesignPatternsInCSharp.Behavioral.Template;
public abstract class  BrewService<T> where T : IBrew, new()
{
    private T? _brew;

    // Template
    public T CreateBrew()
    {
        _brew = new T();
        TakeOrder();
        ProcessPayment();
        BrewBeverage();
        ServeCoffee();
        return _brew;
    }

    protected abstract IBrew BrewBeverage();

    protected virtual bool ProcessPayment() => true;

    private void TakeOrder()
    {
    }

    private void ServeCoffee()
    {
    }
}
