namespace DesignPatternsInCSharp.Structural.Facade;

// Subsystem
public class Credit
{
    public bool HasGoodCredit(Customer costumer)
    {
        Console.WriteLine("Check credit for " + costumer.Name);
        return true;
    }
}
