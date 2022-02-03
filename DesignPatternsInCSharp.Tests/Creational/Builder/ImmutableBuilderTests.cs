using DesignPatternsInCSharp.Creational.Builder.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatternsInCSharp.Tests.Creational.Builder;

[TestClass]
internal class ImmutableBuilderTests
{
    [TestMethod]
    public void MakeImmutableObject_WithDirector_CorrectObjectMade()
    {
        var director = new ConcreteDirector();
        var immutableBuilder = new ConcreteImmutableBuilder();

        director.MakeImmutableObject(immutableBuilder);
        var result = immutableBuilder.Build();
        Assert.AreEqual("", result.ObjectName);
        Assert.AreEqual(0, result.ObjectValue);
    }

    [TestMethod]
    public void MakeImmutableObject_WithoutDirector_CorrectObjectMade()
    {
        var immutableBuilder = new ConcreteImmutableBuilder();
        immutableBuilder.SetName("Teszt");
        immutableBuilder.SetValue(5);

        var result = immutableBuilder.Build();
        Assert.AreEqual("Teszt", result.ObjectName);
        Assert.AreEqual(5, result.ObjectValue);
    }
}
