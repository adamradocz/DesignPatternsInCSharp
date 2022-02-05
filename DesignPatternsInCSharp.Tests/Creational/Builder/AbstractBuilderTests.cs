using AbstractBuilder;
using DesignPatternsInCSharp.Creational.Builder.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPatternsInCSharp.Tests.Creational.Builder;

[TestClass]
public class AbstractBuilderTests
{
    [TestMethod]
    public async Task AbstractBuilder_ObjectSet_ValidObjectBuilt()
    {
        var builder = new AbstractBuilder<TestObject>(() => new TestObject()).Set(x =>
        {
            x.ObjectName = "Teszt";
            x.ObjectValue = 5;
        });

        var cancellationToken = new CancellationTokenSource();
        var builderContext = new BuilderContext() { CancellationToken = cancellationToken.Token };
        var result = await builder.BuildAsync(builderContext);

        Assert.AreEqual(5, result.ObjectValue);
        Assert.AreEqual("Teszt", result.ObjectName);
    }
}
