using DesignPatternsInCSharp.Behavioral.State.RealLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatternsInCSharp.Tests.Behavioral.State.RealLife;

[TestClass]
public class AccountTests
{
    [TestMethod]
    public void Deposit_DepositeToChangeStateToSilver_StateChangedToSilverAccount()
    {
        // Arrange
        var account = new Account();

        // Act
        account.Deposit(1001);

        // Assert
        Assert.AreEqual(nameof(SilverAccountState), account.State.GetType().Name);
    }

    [TestMethod]
    public void Deposit_DepositeToChangeStateToGold_StateChangedToGoldAccount()
    {
        // Arrange
        var account = new Account();

        // Act
        account.Deposit(10001);

        // Assert
        Assert.AreEqual(nameof(GoldAccountState), account.State.GetType().Name);
    }

    [TestMethod]
    public void PayInterest_AccountInBronzeState_InterestNotPayed()
    {
        // Arrange
        var account = new Account();
        account.Deposit(10);

        // Act
        account.PayInterest();

        // Assert
        Assert.AreEqual(10, account.Balance);
        Assert.AreEqual(nameof(BronzAccountState), account.State.GetType().Name);
    }

    [TestMethod]
    public void PayInterest_AccountInSilverState_InterestPayed()
    {
        // Arrange
        var account = new Account();
        account.Deposit(2000);

        // Act
        account.PayInterest();

        // Assert
        Assert.AreEqual(2020, account.Balance);
        Assert.AreEqual(nameof(SilverAccountState), account.State.GetType().Name);
    }

    [TestMethod]
    public void PayInterest_AccountInGoldState_InterestPayed()
    {
        // Arrange
        var account = new Account();
        account.Deposit(100000);

        // Act
        account.PayInterest();

        // Assert
        Assert.AreEqual(110000, account.Balance);
        Assert.AreEqual(nameof(GoldAccountState), account.State.GetType().Name);
    }

    [TestMethod]
    public void Withdraw_WithdrawMoreThanAvailableBalance_BalanceStaysTheSame()
    {
        // Arrange
        var account = new Account();
        account.Deposit(10);

        // Act
        account.Withdraw(20);

        // Assert
        Assert.AreEqual(10, account.Balance);
        Assert.AreEqual(nameof(BronzAccountState), account.State.GetType().Name);
    }

    [TestMethod]
    public void Withdraw_WithdrawLessThanAvailableBalance_BalanceDecreases()
    {
        // Arrange
        var account = new Account();
        account.Deposit(10);

        // Act
        account.Withdraw(7);

        // Assert
        Assert.AreEqual(3, account.Balance);
        Assert.AreEqual(nameof(BronzAccountState), account.State.GetType().Name);
    }

    [TestMethod]
    public void Withdraw_WithdrawTheAllBalanceInSilverState_StateSetToBronze()
    {
        // Arrange
        var account = new Account();
        account.Deposit(6969);
        Assert.AreEqual(nameof(SilverAccountState), account.State.GetType().Name);

        // Act
        account.Withdraw(6969);

        // Assert
        Assert.AreEqual(0, account.Balance);
        Assert.AreEqual(nameof(BronzAccountState), account.State.GetType().Name);
    }
}
