namespace DesignPatternsInCSharp.Structural.Proxy;

public interface IBankAccount
{
    int Deposit(int amount);
    int Withdraw(int amount);
}
