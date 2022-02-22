namespace DesignPatternsInCSharp.Structural.Adapter.Conceptual;

public class Adapter : ITarget
{
    private readonly Adaptee _adaptee;

    public Adapter(Adaptee adaptee)
    {
        _adaptee = adaptee ?? throw new ArgumentNullException(nameof(adaptee));
    }

    public byte[] Request()
    {
        string specificResult = _adaptee.SpecificRequest();
        return System.Text.Encoding.UTF8.GetBytes(specificResult);
    }
}
