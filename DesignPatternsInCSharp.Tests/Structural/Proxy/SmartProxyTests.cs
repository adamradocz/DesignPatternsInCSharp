using DesignPatternsInCSharp.Structural.Proxy.SmartProxy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;

namespace DesignPatternsInCSharp.Tests.Structural.Proxy;

[TestClass]
public class SmartProxyTests
{
    private readonly string _testFile = "output.txt";

    [TestMethod]
    public void OpenWrite_DirectFileAccess_RaisesException()
    {
        //Arrange
        var fs = new DefaultFile();

        byte[] outputBytes1 = Encoding.ASCII.GetBytes("1. andrewlock.net\n");
        byte[] outputBytes2 = Encoding.ASCII.GetBytes("2. weeklydevtips.com\n");

        //Act
        using var file = fs.OpenWrite(_testFile);

        //Assert

        _ = Assert.ThrowsException<IOException>(() => fs.OpenWrite(_testFile)); // try to open a an already-open file
    }

    [TestMethod]
    public void OpenWrite_AccessFile_FileAccessed()
    {
        //Arrange
        var fs = new FileSmartProxy();

        byte[] outputBytes1 = Encoding.ASCII.GetBytes("1. andrewlock.net\n");
        byte[] outputBytes2 = Encoding.ASCII.GetBytes("2. weeklydevtips.com\n");

        //Act
        using var file = fs.OpenWrite(_testFile);
        using var file2 = fs.OpenWrite(_testFile);

        file.Write(outputBytes1);
        file2.Write(outputBytes2);

        file.Close();
        file2.Close();

        //Assert
    }
}
