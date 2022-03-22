using DesignPatternsInCSharp.Behavioral.Chain.Conceptual;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatternsInCSharp.Tests.Behavioral.Chain;

[TestClass]
public class ChainOfCommandTests
{
    [TestMethod]
    public void ChainLoggersCreated_MessagePassed_CorrectMessageReturned()
    {
        //Arrange
        IChainLogger debugChainLogger = new ChainDebugLogger();
        IChainLogger infoChainLogger = new ChainInfoLogger();
        IChainLogger warningChainLogger = new ChainWarningLogger();

        debugChainLogger.SetNextLogger(infoChainLogger);
        infoChainLogger.SetNextLogger(warningChainLogger);
        string testMessage = "Test message";

        //Act
        var debugMessage = debugChainLogger.LogMessage(ChainLogLevel.DEBUG, testMessage);

        //Assert
        Assert.AreEqual($"DEBUG: {testMessage}", debugMessage);

        //Act
        var infoMessage = debugChainLogger.LogMessage(ChainLogLevel.INFO, "Test message");

        //Assert
        Assert.AreEqual($"INFO: {testMessage}", infoMessage);

        //Act
        var warningMessage = debugChainLogger.LogMessage(ChainLogLevel.WARNING, "Test message");

        //Assert
        Assert.AreEqual($"WARNING: {testMessage}", warningMessage);
    }
}
