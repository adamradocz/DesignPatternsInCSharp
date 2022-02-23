using DesignPatternsInCSharp.Structural.Proxy.DynamicProxy;

namespace DesignPatternsInCSharp.Structural.Proxy.SmartProxy;

public class BankAccountSmartLogProxy : IBankAccount
{
    private readonly BankAccount _bankAccount = new();

    public void Deposit(int amount)
    {
        Console.WriteLine($"Invoking {nameof(BankAccount)}.{nameof(Deposit)} with arguments [{amount}]");
        _bankAccount.Deposit(amount);
    }

    public bool Withdraw(int amount)
    {
        Console.WriteLine($"Invoking {nameof(BankAccount)}.{nameof(Withdraw)} with arguments [{amount}]");
        return _bankAccount.Withdraw(amount);
    }
}
