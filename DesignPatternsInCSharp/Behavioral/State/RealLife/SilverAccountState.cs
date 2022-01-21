namespace DesignPatternsInCSharp.Behavioral.State.RealLife;

// Concrate state.
public class SilverAccountState : AccountState
{
    public SilverAccountState(Account account) : base(account)
    {
        Interest = 0.01M;
    }

    protected override void CheckState()
    {
        if (_account.Balance <= BronzUpperLimit)
        {
            _account.State = new BronzAccountState(_account);
        }
        else if (_account.Balance > SilverUpperLimit)
        {
            _account.State = new GoldAccountState(_account);
        }
    }
}