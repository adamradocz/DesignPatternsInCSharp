namespace DesignPatternsInCSharp.Behavioral.Template;

public class Coffee : IBrew
{
    public BrewType Type => BrewType.Coffee;
    public decimal Price => 1;
    public string Name => "Espresso";
}