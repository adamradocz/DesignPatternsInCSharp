namespace DesignPatternsInCSharp.Behavioral.Template;
public class TeaBrewService : BrewService<Tea>
{
    protected override IBrew BrewBeverage() => new Tea();
}
