using DesignPatternsInCSharp.Creational.Builder.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatternsInCSharp.Tests.Creational.Builder;

[TestClass]
public class BuilderWithSourceGeneratorTests
{
    [TestMethod]
    public void Build_AllParametersSet_CorrectObjectBuild()
    {
        var testObject = TestObjectBuilder.TestObject.WithObjectName("Teszt").WithObjectValue(5).Build();

        Assert.AreEqual("Teszt", testObject.ObjectName);
        Assert.AreEqual(5, testObject.ObjectValue);
    }

    [TestMethod]
    public void Build_SomeParametersSet_CorrectObjectBuild()
    {
        var testObject = TestObjectBuilder.TestObject.WithObjectName("Teszt").Build();

        Assert.AreEqual("Teszt", testObject.ObjectName);
        Assert.AreEqual(0, testObject.ObjectValue);
    }
}
