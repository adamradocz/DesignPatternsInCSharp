namespace DesignPatternsInCSharp.Behavioral.State.RealLife;

// Concrate state.
public class GoldAccountState : AccountState
{
    public GoldAccountState(Account account) : base(account)
    {
        Interest = 10;
        LowerLimit = 10000;
    }

    protected override void CheckState()
    {
        if (_account.Balance > UpperLimit)
        {
            _account.State = new GoldAccountState(_account);
        }
        else if (_account.Balance < LowerLimit)
        {
            _account.State = new BronzAccountState(_account);
        }
    }
}