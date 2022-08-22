namespace DesignPatternsInCSharp.Behavioral.Template;

public class Tea : IBrew
{
    public BrewType Type => BrewType.Tea;
    public decimal Price => 1;
    public string Name => "English Breakfast Tea";
}