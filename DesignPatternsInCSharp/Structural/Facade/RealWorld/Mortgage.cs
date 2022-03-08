namespace DesignPatternsInCSharp.Structural.Facade;

// Facade
public class Mortgage
{
    private readonly Bank _bank;
    private readonly Loan _loan;
    private readonly Credit _credit;

    public Mortgage()
    {
        _bank = new Bank();
        _loan = new Loan();
        _credit = new Credit();
    }

    public bool IsEligible(Customer customer, int amount)
    {
        Console.WriteLine($"{customer.Name} applies for {amount:C} loan\n");

        bool eligible = true;
        if (!_bank.HasSufficientSavings(customer))
        {
            eligible = false;
        }
        else if (!_loan.HasNoBadLoans(customer))
        {
            eligible = false;
        }
        else if (!_credit.HasGoodCredit(customer))
        {
            eligible = false;
        }
        return eligible;
    }
}
