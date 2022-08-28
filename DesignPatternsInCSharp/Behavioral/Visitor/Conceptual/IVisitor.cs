namespace DesignPatternsInCSharp.Behavioral.Visitor.Conceptual;
public interface IVisitor
{
    public string Visit(Keyboard keyboard);
    public string Visit(Monitor keyboard);
    public string Visit(Mouse keyboard);
    public string Visit(Computer keyboard);
}
