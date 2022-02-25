using Microsoft.Extensions.Logging;

namespace DesignPatternsInCSharp.Structural.Proxy.Conceptual;

public class BankAccounLogProxy : IBankAccount
{
    private readonly ILogger<BankAccounLogProxy> _logger;
    private readonly IBankAccount _bankAccount;

    public BankAccounLogProxy(ILogger<BankAccounLogProxy> logger, IBankAccount bankAccount)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _bankAccount = bankAccount ?? throw new ArgumentNullException(nameof(bankAccount));
    }

    public int Deposit(int amount)
    {
        _logger.LogInformation("Invoking {ClassName}.{MethodName} with argument {Amount}.", nameof(BankAccount), nameof(Deposit), amount);
        return _bankAccount.Deposit(amount);
    }

    public int Withdraw(int amount)
    {
        _logger.LogInformation("Invoking {ClassName}.{MethodName} with argument {Amount}.", nameof(BankAccount), nameof(Withdraw), amount);
        return _bankAccount.Withdraw(amount);
    }
}
