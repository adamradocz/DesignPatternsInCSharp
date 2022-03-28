namespace DesignPatternsInCSharp.Behavioral.Visitor.Conceptual;
public class Keyboard : IComputer
{
    public string StateOfPart { get; private set; }

    public void Accept(in IVisitor visitor) => StateOfPart = visitor.Visit(this);
}
