namespace DesignPatternsInCSharp.Behavioral.Template;

public class CoffeeBrewService : BrewService<Coffee>
{
    protected override IBrew BrewBeverage() => new Coffee();
}
