using DesignPatternsInCSharp.Structural.Proxy.DynamicProxy;

namespace DesignPatternsInCSharp.Structural.Proxy.SmartProxy;

public class BankAccountSmartProxy : IBankAccount
{
    private BankAccount bankAccount = new();

    public void Deposit(int amount)
    {
        Console.WriteLine($"Invoking {nameof(BankAccount)}.{nameof(Deposit)} with arguments [{amount}]");
        bankAccount.Deposit(amount);
    }

    public bool Withdraw(int amount)
    {
        Console.WriteLine($"Invoking {nameof(BankAccount)}.{nameof(Withdraw)} with arguments [{amount}]");
        return bankAccount.Withdraw(amount);
    }
}
