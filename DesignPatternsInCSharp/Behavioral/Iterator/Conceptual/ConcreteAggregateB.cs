namespace DesignPatternsInCSharp.Behavioral.Iterator.Conceptual;

public class ConcreteAggregateB : IAggregate<string>
{
    private readonly List<string> _items = new() {"A", "B", "C"};

    public IIterator<string> CreateIterator() => new ConcreteIteratorB(_items);
}
