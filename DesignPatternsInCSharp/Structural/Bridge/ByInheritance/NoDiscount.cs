namespace DesignPatternsInCSharp.Structural.Bridge.ByInheritance;

public class NoDiscount : Discount
{
    public override int GetDiscount() => 0;
}
