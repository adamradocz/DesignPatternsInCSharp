namespace DesignPatternsInCSharp.Behavioral.State.RealLife;

// Concrate state.
public class BronzAccountState : AccountState
{
    public BronzAccountState(Account account) : base(account)
    {
        Interest = 0;
    }

    protected override void CheckState()
    {
        if (_account.Balance > SilverUpperLimit)
        {
            _account.State = new GoldAccountState(_account);
        }
        else if (_account.Balance > BronzUpperLimit)
        {
            _account.State = new SilverAccountState(_account);
        }
    }
}
