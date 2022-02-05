namespace DesignPatternsInCSharp.Behavioral.State.RealLife;

// The Context.
public class Account
{
    public decimal Balance { get; set; } = 0;
    public AccountState State { get; set; }

    public Account()
    {
        State = new BronzAccountState(this);
    }

    public void Deposit(decimal amount) => State.Deposit(amount);

    public void Withdraw(decimal amount) => State.Withdraw(amount);

    public void PayInterest() => State.PayInterest();
}
