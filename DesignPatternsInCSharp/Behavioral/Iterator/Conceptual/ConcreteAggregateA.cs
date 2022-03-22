namespace DesignPatternsInCSharp.Behavioral.Iterator.Conceptual;

public class ConcreteAggregateA : IAggregate<string>
{
    private readonly string[] _items;

    public ConcreteAggregateA(string[] items)
    {
        _items = items ?? throw new ArgumentNullException(nameof(items));
    }

    public IIterator<string> CreateIterator() => new ConcreteIteratorA(_items);
}
