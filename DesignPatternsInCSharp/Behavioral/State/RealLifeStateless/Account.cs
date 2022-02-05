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
            .PermitIf(AccountAction.Deposit, AccountState.Silver, () => IsInSilverState())
            .PermitIf(AccountAction.Deposit, AccountState.Gold, () => IsInGoldState())
            .PermitReentryIf(AccountAction.Deposit, () => IsInBronzState())
            .Ignore(AccountAction.Withdraw);

        _stateMachine.Configure(AccountState.Silver)
            .OnEntry(() => _interest = 0.01M)
            .PermitIf(AccountAction.Deposit, AccountState.Gold, () => IsInGoldState())
            .PermitIf(AccountAction.Withdraw, AccountState.Bronz, () => IsInBronzState())
            .PermitReentryIf(AccountAction.Deposit, () => IsInSilverState())
            .PermitReentryIf(AccountAction.Withdraw, () => IsInSilverState());

        _stateMachine.Configure(AccountState.Gold)
            .OnEntry(() => _interest = 0.1M)
            .PermitIf(AccountAction.Withdraw, AccountState.Bronz, () => IsInBronzState())
            .PermitIf(AccountAction.Withdraw, AccountState.Silver, () => IsInSilverState())
            .PermitReentryIf(AccountAction.Withdraw, () => IsInGoldState())
            .Ignore(AccountAction.Deposit);
    }

    private bool IsInBronzState() => Balance <= BronzUpperLimit;

    private bool IsInSilverState() => Balance > BronzUpperLimit && Balance <= SilverUpperLimit;

    private bool IsInGoldState() => Balance > SilverUpperLimit;

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
