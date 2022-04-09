namespace DesignPatternsInCSharp.Behavioral.Template;
public abstract class  BrewService<T> where T : IBrew, new()
{
    protected T Brew;

    // Template
    public T CreateBrew()
    {
        Brew = new T();
        TakeOrder();
        ProcessPayment();
        BrewBeverage();
        ServeCoffee();
        return Brew;
    }

    public abstract IBrew BrewBeverage();

    protected virtual bool ProcessPayment() => true;

    private void TakeOrder()
    {
    }

    private void ServeCoffee()
    {
    }
}
