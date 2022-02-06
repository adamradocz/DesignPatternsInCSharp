using DesignPatternsInCSharp.Creational.Prototype.MemberwiseClone;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatternsInCSharp.Tests.Creational.Prototype;

[TestClass]
public class MemberwiseCloneTests
{
    [TestMethod]
    public void Clone_NoChangeTaken_PropertiesAreEqual()
    {
        // Arrange
        Address address = new()
        {
            StreetName = "Main Street",
            HouseNumber = 123
        };

        Person joe = new()
        {
            Name = "Joe",
            Age = 96,
            Address = address
        };

        // Act
        var otherJoe = joe.ShallowClone();

        // Assert
        Assert.AreNotSame(joe, otherJoe);
        Assert.AreNotEqual(joe, otherJoe);
        Assert.AreEqual(joe.Name, otherJoe.Name);
        Assert.AreEqual(joe.Age, otherJoe.Age);
        Assert.AreSame(joe.Address, otherJoe.Address);
        Assert.AreEqual(joe.Address, otherJoe.Address);
        Assert.AreEqual(joe.Address.StreetName, otherJoe.Address.StreetName);
        Assert.AreEqual(joe.Address.HouseNumber, otherJoe.Address.HouseNumber);
    }

    [TestMethod]
    public void Clone_ChangeTheClonedProperties_AddressPropertiesAreEqual()
    {
        // Arrange
        Address address = new()
        {
            StreetName = "Main Street",
            HouseNumber = 123
        };

        Person joe = new()
        {
            Name = "Joe",
            Age = 96,
            Address = address
        };

        // Act
        var jane = joe.ShallowClone();
        jane.Name = "Jane";
        jane.Age = 69;
        jane.Address.StreetName = "Sub Street";
        jane.Address.HouseNumber = 321;

        // Assert
        Assert.AreNotSame(joe, jane);
        Assert.AreNotEqual(joe, jane);
        Assert.AreNotEqual(joe.Name, jane.Name);
        Assert.AreNotEqual(joe.Age, jane.Age);
        Assert.AreSame(joe.Address, jane.Address);
        Assert.AreEqual(joe.Address, jane.Address);
        Assert.AreEqual(joe.Address.StreetName, jane.Address.StreetName);
        Assert.AreEqual(joe.Address.HouseNumber, jane.Address.HouseNumber);

        Assert.AreEqual("Joe", joe.Name);
        Assert.AreEqual(96, joe.Age);
        Assert.AreEqual("Sub Street", joe.Address.StreetName);
        Assert.AreEqual(321, joe.Address.HouseNumber);

        Assert.AreEqual("Jane", jane.Name);
        Assert.AreEqual(69, jane.Age);
        Assert.AreEqual("Sub Street", jane.Address.StreetName);
        Assert.AreEqual(321, jane.Address.HouseNumber);
    }

    [TestMethod]
    public void DeepClone_NoChangeTaken_PropertiesAreEqual()
    {
        // Arrange
        Address address = new()
        {
            StreetName = "Main Street",
            HouseNumber = 123
        };

        Person joe = new()
        {
            Name = "Joe",
            Age = 96,
            Address = address
        };

        // Act
        var otherJoe = joe.DeepClone();

        // Assert
        Assert.AreNotSame(joe, otherJoe);
        Assert.AreNotEqual(joe, otherJoe);
        Assert.AreEqual(joe.Name, otherJoe.Name);
        Assert.AreEqual(joe.Age, otherJoe.Age);
        Assert.AreNotSame(joe.Address, otherJoe.Address);
        Assert.AreNotEqual(joe.Address, otherJoe.Address);
        Assert.AreEqual(joe.Address.StreetName, otherJoe.Address.StreetName);
        Assert.AreEqual(joe.Address.HouseNumber, otherJoe.Address.HouseNumber);
    }

    [TestMethod]
    public void DeepClone_ChangeTheClonedProperties_AddressPropertiesAreNotEqual()
    {
        // Arrange
        Address address = new()
        {
            StreetName = "Main Street",
            HouseNumber = 123
        };

        Person joe = new()
        {
            Name = "Joe",
            Age = 96,
            Address = address
        };

        // Act
        var jane = joe.DeepClone();
        jane.Name = "Jane";
        jane.Age = 69;
        jane.Address.StreetName = "Sub Street";
        jane.Address.HouseNumber = 321;

        // Assert
        Assert.AreNotSame(joe, jane);
        Assert.AreNotEqual(joe, jane);
        Assert.AreNotEqual(joe.Name, jane.Name);
        Assert.AreNotEqual(joe.Age, jane.Age);
        Assert.AreNotSame(joe.Address, jane.Address);
        Assert.AreNotEqual(joe.Address, jane.Address);
        Assert.AreNotEqual(joe.Address.StreetName, jane.Address.StreetName);
        Assert.AreNotEqual(joe.Address.HouseNumber, jane.Address.HouseNumber);

        Assert.AreEqual("Joe", joe.Name);
        Assert.AreEqual(96, joe.Age);
        Assert.AreEqual("Main Street", joe.Address.StreetName);
        Assert.AreEqual(123, joe.Address.HouseNumber);

        Assert.AreEqual("Jane", jane.Name);
        Assert.AreEqual(69, jane.Age);
        Assert.AreEqual("Sub Street", jane.Address.StreetName);
        Assert.AreEqual(321, jane.Address.HouseNumber);
    }
}
