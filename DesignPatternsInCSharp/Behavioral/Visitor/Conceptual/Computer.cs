namespace DesignPatternsInCSharp.Behavioral.Visitor.Conceptual;
public class Computer : IComputer
{
    private readonly IComputer[] _parts;

    public string StateOfPart { get; private set; }

    public string[] StateOfParts { get; }

    public Computer()
    {
        _parts = new IComputer[] { new Mouse(), new Monitor(), new Keyboard() };
        StateOfParts = new string[_parts.Length + 1];
    }

    public void Accept(in IVisitor visitor)
    {
        for (int i = 0; i < _parts.Length; i++)
        {
            _parts[i].Accept(visitor);
            StateOfParts[i] = _parts[i].StateOfPart;
        }

        StateOfPart = visitor.Visit(this);

        StateOfParts[_parts.Length] = StateOfPart;
    }
}
