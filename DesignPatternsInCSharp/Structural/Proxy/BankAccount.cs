namespace DesignPatternsInCSharp.Structural.Proxy;

public class BankAccount : IBankAccount
{
    private int _balance = 0;

    public int Deposit(int amount)
    {
        _balance += amount;
        return _balance;
    }

    public int Withdraw(int amount)
    {
        _balance -= amount;
        return _balance;
    }
}

