using DesignPatternsInCSharp.Structural.Proxy;
using DesignPatternsInCSharp.Structural.Proxy.Conceptual;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DesignPatternsInCSharp.Tests.Structural.Proxy;

[TestClass]
public class ConceptualTests
{
    [TestMethod]
    public void Deposit_AddAmount_ReturnsBalance()
    {
        // Arrange
        var bankAccount = new BankAccount();
        var loggerFactory = new LoggerFactory();
        var bankAccountLogProxy = new BankAccounLogProxy(loggerFactory.CreateLogger<BankAccounLogProxy>(), new BankAccount());
        int amount = 100;

        //Act
        int balance = bankAccount.Deposit(amount);
        int proxyBalance = bankAccountLogProxy.Deposit(amount);

        //Asert
        Assert.Equals(balance, proxyBalance);
    }

    [TestMethod]
    public void Withdraw_AddAmount_ReturnsBalance()
    {
        // Arrange
        var bankAccount = new BankAccount();
        var loggerFactory = new LoggerFactory();
        var bankAccountLogProxy = new BankAccounLogProxy(loggerFactory.CreateLogger<BankAccounLogProxy>(), new BankAccount());
        int amount = 100;

        //Act
        int balance = bankAccount.Withdraw(amount);
        int proxyBalance = bankAccountLogProxy.Withdraw(amount);

        //Asert
        Assert.Equals(balance, proxyBalance);
    }
}
