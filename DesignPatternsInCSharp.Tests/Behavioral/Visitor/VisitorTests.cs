using DesignPatternsInCSharp.Behavioral.Visitor.Conceptual;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DesignPatternsInCSharp.Tests.Behavioral.Visitor;

[TestClass]
public class VisitorTests
{
    [TestMethod]
    public void ElementWithVisitor_AcceptsVisitor_ExecutesCorrectBehavior()
    {
        //Arrange
        var computer = new Computer();

        //Act
        computer.Accept(new ComputerPartVisitor());

        //Assert
        Assert.IsTrue(computer.StateOfParts.Contains("Plugging in mouse."));
        Assert.IsTrue(computer.StateOfParts.Contains("Turning on Monitor."));
        Assert.IsTrue(computer.StateOfParts.Contains("Setting up keyboard."));
        Assert.IsTrue(computer.StateOfParts.Contains("Booting up OS."));
    }
}
