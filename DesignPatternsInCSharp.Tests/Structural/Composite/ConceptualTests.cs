using DesignPatternsInCSharp.Structural.Composite.Conceptual;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatternsInCSharp.Tests.Structural.Composite;

[TestClass]
public class ConceptualTests
{
    [TestMethod]
    public void Deposit_AddAmount_ReturnsBalance()
    {
        // Arrange
        var watch = new Product(200);
        var parfume = new Product(100);
        var dress = new Product(200);

        var phone = new Product(200);
        var book = new Product(100);
        var subscription = new Product(200);

        var airPurifier = new Product(5969);

        var wifeyBox = new BoxComposite();
        wifeyBox.Add(watch);
        wifeyBox.Add(parfume);
        wifeyBox.Add(dress);

        var hubbyBox = new BoxComposite();
        hubbyBox.Add(phone);
        hubbyBox.Add(book);
        hubbyBox.Add(subscription);

        var familyBox = new BoxComposite(); // Root component
        familyBox.Add(wifeyBox); // Composite
        familyBox.Add(hubbyBox); // Composite
        familyBox.Add(airPurifier); // Leaf
        
        // Act
        var totalPrice = familyBox.CalculatePrice();

        // Assert
        Assert.AreEqual(6969, totalPrice);
    }
}
