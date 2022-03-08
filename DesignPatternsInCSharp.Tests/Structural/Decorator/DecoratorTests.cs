using DesignPatternsInCSharp.Structural.Decorator.Naive;
using DesignPatternsInCSharp.Structural.Decorator.RealLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatternsInCSharp.Tests.Structural.Decorator;

[TestClass]
public class DecoratorTests
{
    [TestMethod]
    public void DoStuff_BaseDecoratorUsed_ReturnsWithBaseValue()
    {
        //Arrange
        ICommonInterface component = new ConcreteComponent();
        ICommonInterface decorator = new BaseDecorator(component);

        //Act
        decorator.DoStuff("TestParameter");

        //Assert
        Assert.AreEqual("TestParameter", decorator.CurrentData);
    }

    [TestMethod]
    public void DoStuff_ConcreteDecoratorUsed_ReturnsWithDecoratedValue()
    {
        //Arrange
        ICommonInterface component = new ConcreteComponent();
        ICommonInterface decorator = new ConcreteDecorator(component);

        //Act
        decorator.DoStuff("TestParameter");

        //Assert
        Assert.AreEqual("TestParameter decorated with ConcreteDecorator", decorator.CurrentData);
    }

    [TestMethod]
    public void CreateCar_AddExtras_PriceChanges()
    {
        //Arrange
        ICar sedan = new Sedan(1000);
        Assert.AreEqual(1000,sedan.Price);

        //Act
        ICar carWithAC = new SedanWithAC(sedan);

        //Assert
        Assert.AreEqual(1200, carWithAC.Price);
    }

    [TestMethod]
    public void CreateCar_AddExtrasInDifferentOrders_OutcomeIsTheSame()
    {
        //Arrange
        ICar firstCar = new Sedan(1000);
        ICar secondCar = new Sedan(1000);

        Assert.AreEqual(1000, firstCar.Price);
        Assert.AreEqual(1000, secondCar.Price);

        //Act
        ICar firstCarWithAC = new SedanWithAC(firstCar);
        ICar secondCarWithHeating = new SedanWithHeatedSeats(secondCar);

        ICar firstFinalCar = new SedanWithHeatedSeats(firstCarWithAC);
        ICar secondFinalCar = new SedanWithAC(secondCarWithHeating);

        //Assert
        Assert.AreEqual(firstFinalCar.Price, secondFinalCar.Price);
    }
}
