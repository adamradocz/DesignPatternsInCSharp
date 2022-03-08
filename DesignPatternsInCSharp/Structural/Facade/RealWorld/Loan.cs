namespace DesignPatternsInCSharp.Structural.Facade;

// Subsystem
public class Loan
{
    public bool HasNoBadLoans(Customer costumer)
    {
        Console.WriteLine("Check loans for " + costumer.Name);
        return true;
    }
}
