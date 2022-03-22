namespace DesignPatternsInCSharp.Behavioral.Iterator.Conceptual;

public class ConcreteAggregateB : IAggregate<string>
{
    private readonly List<string> _items;

    public ConcreteAggregateB(List<string> items)
    {
        _items = items ?? throw new ArgumentNullException(nameof(items));
    }

    public IIterator<string> CreateIterator() => new ConcreteIteratorB(_items);
}
