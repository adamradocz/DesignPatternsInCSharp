namespace DesignPatternsInCSharp.Behavioral.Template;
public abstract class  BrewService<T> where T : IBrew, new()
{
    protected T Brew;

    // Template
    public T CreateCoffee()
    {
        Brew = new T();
        TakeOrder();
        ProcessPayment();
        BrewCoffee();
        ServeCoffee();
        return Brew;
    }

    public abstract IBrew BrewCoffee();

    protected virtual bool ProcessPayment() => true;

    private void TakeOrder()
    {
    }

    private void ServeCoffee()
    {
    }
}
