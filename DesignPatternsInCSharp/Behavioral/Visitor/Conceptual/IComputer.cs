namespace DesignPatternsInCSharp.Behavioral.Visitor.Conceptual;
public interface IComputer
{
    public string StateOfPart { get; }
    public void Accept(in IVisitor visitor);
}
