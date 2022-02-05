using DesignPatternsInCSharp.Creational.Builder.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatternsInCSharp.Tests.Creational.Builder;

[TestClass]
public class BuilderTests
{
    [TestMethod]
    public void MakeObject_WithDirector_CorrectObjectMade()
    {
        var director = new ConcreteDirector();
        var concreteBuilder = new ConcreteBuilder();

        director.MakeObject(concreteBuilder);
        var result = concreteBuilder.Build();
        Assert.AreEqual("", result.ObjectName);
        Assert.AreEqual(0, result.ObjectValue);
    }

    [TestMethod]
    public void MakeObject_WithoutDirector_CorrectObjectMade()
    {
        var concreteBuilder = new ConcreteBuilder();
        concreteBuilder.SetName("Teszt");
        concreteBuilder.SetValue(5);

        var result = concreteBuilder.Build();
        Assert.AreEqual("Teszt", result.ObjectName);
        Assert.AreEqual(5,result.ObjectValue);
    }
}
