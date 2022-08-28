namespace DesignPatternsInCSharp.Behavioral.Visitor.Conceptual;
public class ComputerPartVisitor : IVisitor
{
    public string Visit(Keyboard keyboard) => "Setting up keyboard.";
    public string Visit(Monitor keyboard) => "Turning on Monitor.";
    public string Visit(Mouse keyboard) => "Plugging in mouse.";
    public string Visit(Computer keyboard) => "Booting up OS.";
}
