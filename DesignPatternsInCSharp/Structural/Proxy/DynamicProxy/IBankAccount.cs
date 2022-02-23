namespace DesignPatternsInCSharp.Structural.Proxy.DynamicProxy;

public interface IBankAccount
{
    void Deposit(int amount);
    bool Withdraw(int amount);
}
