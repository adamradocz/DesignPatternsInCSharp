namespace DesignPatternsInCSharp.Behavioral.State.RealLife;

// Concrate state.
public class GoldAccountState : AccountState
{
    public GoldAccountState(Account account) : base(account)
    {
        Interest = 0.1M;
    }

    protected override void CheckState()
    {
        if (_account.Balance <= BronzUpperLimit)
        {
            _account.State = new BronzAccountState(_account);
        }
        else if(_account.Balance <= SilverUpperLimit)
        {
            _account.State = new SilverAccountState(_account);
        }
    }
}