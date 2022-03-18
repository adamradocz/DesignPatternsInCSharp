namespace DesignPatternsInCSharp.Behavioral.Iterator.Conceptual;

public class ConcreteAggregateA : IAggregate<string>
{
    private readonly string[] _items = new string[] {"0", "1", "2"};

    public IIterator<string> CreateIterator() => new ConcreteIteratorA(_items);
}
