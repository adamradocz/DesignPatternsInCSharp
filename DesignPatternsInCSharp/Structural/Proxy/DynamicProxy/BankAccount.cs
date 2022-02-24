namespace DesignPatternsInCSharp.Structural.Proxy.DynamicProxy;

public class BankAccount : IBankAccount
{
    private int _balance;
    private readonly int _overdraftLimit = -500;

    public void Deposit(int amount)
    {
        _balance += amount;
        Console.WriteLine($"Deposited ${amount}, balance is now {_balance}");
    }

    public bool Withdraw(int amount)
    {
        if (_balance - amount >= _overdraftLimit)
        {
            _balance -= amount;
            Console.WriteLine($"Withdrew ${amount}, balance is now {_balance}");
            return true;
        }
        return false;
    }
}

