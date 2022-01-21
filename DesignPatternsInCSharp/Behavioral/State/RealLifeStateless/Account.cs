using Stateless;

namespace DesignPatternsInCSharp.Behavioral.State.RealLifeStateless;

// The Context.
public class Account
{
    private const decimal BronzUpperLimit = 1000;
    private const decimal SilverUpperLimit = 10000;

    private readonly StateMachine<AccountState, AccountAction> _stateMachine;
    private decimal _interest = 0;

    public decimal Balance { get; set; } = 0;
    public AccountState State => _stateMachine.State;

    public Account()
    {
        _stateMachine = new(AccountState.Bronz);

        _stateMachine.Configure(AccountState.Bronz)
            .OnEntry(() => _interest = 0)
            .PermitReentry(AccountAction.Deposit)
            .PermitIf(AccountAction.Deposit, AccountState.Silver, () => (Balance > BronzUpperLimit && Balance <= SilverUpperLimit))
            .PermitIf(AccountAction.Deposit, AccountState.Gold, () => Balance > SilverUpperLimit);
            

        _stateMachine.Configure(AccountState.Silver)
            .PermitIf(AccountAction.Deposit, AccountState.Gold, () => Balance > SilverUpperLimit)
            .PermitIf(AccountAction.Withdraw, AccountState.Bronz, () => Balance <= BronzUpperLimit)
            .OnEntry(() => _interest = 0.01M);

        _stateMachine.Configure(AccountState.Gold)
            .PermitIf(AccountAction.Withdraw, AccountState.Bronz, () => Balance <= BronzUpperLimit)
            .PermitIf(AccountAction.Withdraw, AccountState.Silver, () => Balance <= SilverUpperLimit && Balance > BronzUpperLimit)
            .OnEntry(() => _interest = 0.1M);
    }

    public void Deposit(decimal amount)
    {
        Balance += amount;
        _stateMachine.Fire(AccountAction.Deposit);
    }
    public bool Withdraw(decimal amount)
    {
        decimal newBalance = Balance - amount;
        if (newBalance >= 0)
        {
            Balance = newBalance;
            _stateMachine.Fire(AccountAction.Withdraw);
            return true;
        }

        return false;
    }

    public void PayInterest()
    {
        Balance += _interest * Balance;
        _stateMachine.Fire(AccountAction.Deposit);
    }
}
