namespace DesignPatternsInCSharp.Behavioral.Iterator.Conceptual;

public class ConcreteIteratorB : IIterator<string>
{
    private readonly List<string> _items;

    private int _currentItem = 0;

    public ConcreteIteratorB(List<string> items)
    {
        _items = items;
    }

    public string CurrentItem() => _items[_currentItem];

    public string First()
    {
        _currentItem = 0;
        return CurrentItem();
    }

    public bool IsDone() => _currentItem >= _items.Count;

    public string? Next()
    {
        _currentItem++;

        return IsDone() ? null : CurrentItem();
    }
}
