namespace DesignPatternsInCSharp.Behavioral.State.RealLife;

// Concrate state.
public class BronzAccountState : AccountState
{
    public BronzAccountState(Account account) : base(account)
    {
        Interest = 0;
        LowerLimit = 0;
        UpperLimit = 1000;
    }

    protected override void CheckState()
    {
        if (_account.Balance > UpperLimit)
        {
            _account.State = new SilverAccountState(_account);
        }
    }
}
