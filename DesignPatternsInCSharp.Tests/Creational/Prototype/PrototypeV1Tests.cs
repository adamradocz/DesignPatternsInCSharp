using DesignPatternsInCSharp.Creational.PrototypeV1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DesignPatternsInCSharp.Tests.Creational.PrototypeV1;

[TestClass]
public class PrototypeV1Tests
{

    [TestMethod]
    public void PrototypeV1TestsTestMethod()
    {
        //SallowCopy_Copyed_ObjectsAreTheSame
       
        // Arrange
        Person p1 = new Person();
        p1.Age = 42;
        p1.Name = "Jack Daniels";
        p1.IdInfo = new IdInfo(666);

        // Act
        // Perform a shallow copy of p1 and assign it to p2.
        Person p2 = p1.ShallowCopy();
        // Make a deep copy of p1 and assign it to p3.
        Person p3 = p1.DeepCopy();

        // Assert
        Assert.AreEqual(p1.IdInfo, p2.IdInfo);
        Assert.AreEqual(p1.Name, p2.Name);
        Assert.AreEqual(p1.Age, p2.Age);
        Assert.AreNotEqual(p1.IdInfo, p3.IdInfo);
        Assert.AreEqual(p1.Name, p3.Name);
        Assert.AreEqual(p1.Age, p3.Age);
    }

    [TestMethod]
    public void PrototypeV1TestsTestMethod2()
    {

        // Arrange
        Person p1 = new Person();
        p1.Age = 42;
        p1.Name = "Jack Daniels";
        p1.IdInfo = new IdInfo(666);

        // Act
        // Perform a shallow copy of p1 and assign it to p2.
        Person p2 = p1.ShallowCopy();
        // Make a deep copy of p1 and assign it to p3.
        Person p3 = p1.DeepCopy();
        // Change the value of p1 properties and display the values of p1,
        // p2 and p3.
        p1.Age = 32;
        p1.Name = "Frank";
        p1.IdInfo.IdNumber = 7878;

        // Assert
        Assert.AreEqual(p1.IdInfo, p2.IdInfo);
        Assert.AreNotEqual(p1.Name, p2.Name);
        Assert.AreNotEqual(p1.Age, p2.Age);
        Assert.AreNotEqual(p1.IdInfo, p3.IdInfo);
        Assert.AreNotEqual(p1.Name, p3.Name);
        Assert.AreNotEqual(p1.Age, p3.Age);
    }
}
