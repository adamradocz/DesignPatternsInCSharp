namespace DesignPatternsInCSharp.Behavioral.Iterator.Conceptual;

public class ConcreteIteratorA : IIterator<string>
{
    private readonly string[] _items;

    private int _currentItem = 0;

    public ConcreteIteratorA(string[] items)
    {
        _items = items;
    }

    public string CurrentItem() => _items[_currentItem];

    public string First()
    {
        _currentItem = 0;
        return CurrentItem();
    }

    public bool IsDone() => _currentItem >= _items.Length;

    public string? Next()
    {
        _currentItem++;

        return IsDone() ? null : CurrentItem();
    }
}
