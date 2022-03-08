using DesignPatternsInCSharp.Structural.Proxy;
using DesignPatternsInCSharp.Structural.Proxy.Dynamic;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatternsInCSharp.Tests.Structural.Proxy;

[TestClass]
public class DynamicTests
{
    [TestMethod]
    public void Deposit_AddAmount_ReturnsBalance()
    {
        // Arrange
        var bankAccount = new BankAccount();
        var loggerFactory = new LoggerFactory();
        var bankAccountLogProxy = Log<BankAccount>.As<IBankAccount>(loggerFactory.CreateLogger<BankAccount>());
        int amount = 100;

        //Act
        int balance = bankAccount.Deposit(amount);
        int proxyBalance = bankAccountLogProxy.Deposit(amount);

        //Asert
        Assert.AreEqual(balance, proxyBalance);
    }

    [TestMethod]
    public void Withdraw_AddAmount_ReturnsBalance()
    {
        // Arrange
        var bankAccount = new BankAccount();
        var loggerFactory = new LoggerFactory();
        var bankAccountLogProxy = Log<BankAccount>.As<IBankAccount>(loggerFactory.CreateLogger<BankAccount>());
        int amount = 100;

        //Act
        int balance = bankAccount.Withdraw(amount);
        int proxyBalance = bankAccountLogProxy.Withdraw(amount);

        //Asert
        Assert.AreEqual(balance, proxyBalance);
    }
}
