namespace DesignPatternsInCSharp.Behavioral.Template;
public class TeaBrewService : BrewService<Tea>
{
    public override IBrew BrewCoffee() => new Tea();
}
