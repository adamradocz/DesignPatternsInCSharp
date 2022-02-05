namespace DesignPatternsInCSharp.Behavioral.State.RealLife;

// The Abstract State.
public abstract class AccountState
{
    internal const decimal BronzUpperLimit = 1000;
    internal const decimal SilverUpperLimit = 10000;

    internal Account _account;
    public decimal Interest { get; internal set; }

    public AccountState(Account account)
    {
        _account = account ?? throw new ArgumentNullException(nameof(account));
    }

    public void Deposit(decimal amount)
    {
        _account.Balance += amount;
        CheckState();
    }

    public bool Withdraw(decimal amount)
    {
        decimal newBalance = _account.Balance - amount;
        if (newBalance >= 0)
        {
            _account.Balance = newBalance;
            CheckState();
            return true;
        }

        return false;
    }

    public void PayInterest()
    {
        _account.Balance += Interest * _account.Balance;
        CheckState();
    }

    protected abstract void CheckState();
}
