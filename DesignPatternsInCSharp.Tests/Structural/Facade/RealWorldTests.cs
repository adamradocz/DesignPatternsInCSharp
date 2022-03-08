using DesignPatternsInCSharp.Structural.Facade;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatternsInCSharp.Tests.Structural.Facade;

[TestClass]
public class RealWorldTests
{
    [TestMethod]
    public void Facade_AndGroupOfServices_GivesTheSameResult()
    {
        // Arrange
        Customer customer = new("Damon Smith");
        Credit credit = new();
        Loan loan = new();
        Bank bank = new();
        Mortgage mortgage = new();

        // Act
        bool mortgageEligible = credit.HasGoodCredit(customer) && bank.HasSufficientSavings(customer) && loan.HasNoBadLoans(customer);
        bool facadeMortgageEligible = mortgage.IsEligible(customer, 7000);

        // Assert
        Assert.AreEqual(mortgageEligible, facadeMortgageEligible);
    }
}
