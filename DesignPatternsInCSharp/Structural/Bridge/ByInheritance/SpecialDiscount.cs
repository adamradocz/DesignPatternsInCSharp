namespace DesignPatternsInCSharp.Structural.Bridge.ByInheritance;

public class SpecialDiscount : Discount
{
    public override int GetDiscount() => 10;
}
