namespace DesignPatternsInCSharp.Behavioral.Template;

public class CoffeeBrewService : BrewService<Coffee>
{
    public override IBrew BrewCoffee() => new Coffee();
}
