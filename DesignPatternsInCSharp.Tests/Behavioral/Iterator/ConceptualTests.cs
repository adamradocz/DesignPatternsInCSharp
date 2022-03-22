using DesignPatternsInCSharp.Behavioral.Iterator.Conceptual;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DesignPatternsInCSharp.Tests.Behavioral.Iterator;

[TestClass]
public class ConceptualTests
{
    private readonly string[] _itemsA = new string[] { "A", "B", "C" };
    private readonly List<string> _itemsB = new() { "D", "E", "F" };

    [TestMethod]
    public void Iterate_ThreeElementCounted()
    {
        // Arrange        
        var concreteAggregateA = new ConcreteAggregateA(_itemsA);
        var concreteIteratorA = concreteAggregateA.CreateIterator();

        var concreteAggregateB = new ConcreteAggregateB(_itemsB);
        var concreteIteratorB = concreteAggregateB.CreateIterator();

        // Act
        int elementCountedA = 0;
        while (!concreteIteratorA.IsDone())
        {
            elementCountedA++;
            _ = concreteIteratorA.Next();
        }

        int elementCountedB = 0;
        while (!concreteIteratorB.IsDone())
        {
            elementCountedB++;
            _ = concreteIteratorB.Next();
        }

        // Assert
        Assert.AreEqual(_itemsA.Length, elementCountedA);
        Assert.AreEqual(_itemsB.Count, elementCountedB);
    }

    [TestMethod]
    public void CurrentItem_NextNotCalled_SameAsFirstItem()
    {
        // Arrange        
        var concreteAggregateA = new ConcreteAggregateA(_itemsA);
        var concreteIteratorA = concreteAggregateA.CreateIterator();

        var concreteAggregateB = new ConcreteAggregateB(_itemsB);
        var concreteIteratorB = concreteAggregateB.CreateIterator();

        // Act
        string? currentItemA = concreteIteratorA.CurrentItem();
        string? currentItemB = concreteIteratorB.CurrentItem();

        // Assert
        Assert.AreEqual(_itemsA[0], currentItemA);
        Assert.AreEqual(_itemsB[0], currentItemB);
    }

    [TestMethod]
    public void CurrentItem_NextCalled_SameAsSecondItem()
    {
        // Arrange
        var concreteAggregateA = new ConcreteAggregateA(_itemsA);
        var concreteIteratorA = concreteAggregateA.CreateIterator();

        var concreteAggregateB = new ConcreteAggregateB(_itemsB);
        var concreteIteratorB = concreteAggregateB.CreateIterator();

        // Act
        string? currentItemA = concreteIteratorA.Next();
        string? currentItemB = concreteIteratorB.Next();

        // Assert
        Assert.AreEqual(_itemsA[1], currentItemA);
        Assert.AreEqual(_itemsB[1], currentItemB);
    }

    [TestMethod]
    public void First_NextCalled_SameAsFirstItem()
    {
        // Arrange
        var concreteAggregateA = new ConcreteAggregateA(_itemsA);
        var concreteIteratorA = concreteAggregateA.CreateIterator();

        var concreteAggregateB = new ConcreteAggregateB(_itemsB);
        var concreteIteratorB = concreteAggregateB.CreateIterator();

        // Act
        _ = concreteIteratorA.Next();
        _ = concreteIteratorB.Next();
        string? currentItemA = concreteIteratorA.First();
        string? currentItemB = concreteIteratorB.First();

        // Assert
        Assert.AreEqual(_itemsA[0], currentItemA);
        Assert.AreEqual(_itemsB[0], currentItemB);
    }
}
