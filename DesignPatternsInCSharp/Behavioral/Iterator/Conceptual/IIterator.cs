namespace DesignPatternsInCSharp.Behavioral.Iterator.Conceptual;

public interface IIterator<T> where T : class
{
    public T First();
    public T? Next();
    public bool IsDone();
    public T CurrentItem();
}
