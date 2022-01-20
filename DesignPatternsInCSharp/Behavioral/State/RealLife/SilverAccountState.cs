namespace DesignPatternsInCSharp.Behavioral.State.RealLife;

// Concrate state.
public class SilverAccountState : AccountState
{
    public SilverAccountState(Account account) : base(account)
    {
        Interest = 0.01M;
        LowerLimit = 1000;
        UpperLimit = 10000;
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