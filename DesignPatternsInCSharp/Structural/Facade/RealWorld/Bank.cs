namespace DesignPatternsInCSharp.Structural.Facade;

// Subsystem
public class Bank
{
    public bool HasSufficientSavings(Customer c)
    {
        Console.WriteLine("Check bank for " + c.Name);
        return true;
    }
}
