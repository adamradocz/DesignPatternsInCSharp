namespace DesignPatternsInCSharp.Structural.Bridge.ByInheritance;

public class SeniorDiscount : Discount
{
    public override int GetDiscount() => 20;
}
