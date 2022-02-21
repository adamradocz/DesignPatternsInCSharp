using DesignPatternsInCSharp.Structural.Proxy.ProtectiveProxy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DesignPatternsInCSharp.Tests.Structural.Proxy;

[TestClass]
public class ProtectiveProxyTests
{
    private readonly Employee _other;
    private readonly Employee _admin;

    public ProtectiveProxyTests()
    {
        _other = new Employee("otheruser" , "Your_password123", "simpleuser");
        _admin = new Employee("admin" , "Your_password123", "admin");
        
    }

    [TestMethod]
    public void Write_NotAdminEmployeeTrytoWrite_UnauthorizedAccessExceptionThrown()
    {
        // Arrange
        SharedFolder sharedFolder = SharedFolder.Create("admin's public");

        //Act

        //Asert
        _ = Assert.ThrowsException<UnauthorizedAccessException>(() => sharedFolder.Write(_other));
    }

    [TestMethod]
    public void Write_AdminEmployeeTrytoWrite_WritesSuccessfully()
    {
        // Arrange
        SharedFolder sharedFolder = SharedFolder.Create("admin's public");

        //Act
        sharedFolder.Write(_admin);

        //Asert
    }
}
