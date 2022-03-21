namespace DesignPatternsInCSharp.Behavioral.Iterator.Conceptual;

public interface IAggregate<T> where T : class
{
    public IIterator<T> CreateIterator();
}
