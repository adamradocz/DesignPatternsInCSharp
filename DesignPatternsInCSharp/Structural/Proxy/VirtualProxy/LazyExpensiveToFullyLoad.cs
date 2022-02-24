namespace DesignPatternsInCSharp.Structural.Proxy.VirtualProxy;

public class LazyExpensiveToFullyLoad
{
    private readonly Lazy<IEnumerable<ExpensiveEntity>> _homeEntities;
    private readonly Lazy<IEnumerable<ExpensiveEntity>> _awayEntities;

    public IEnumerable<ExpensiveEntity> HomeEntities => _homeEntities.Value;
    public IEnumerable<ExpensiveEntity> AwayEntities => _awayEntities.Value;

    public LazyExpensiveToFullyLoad()
    {
        _homeEntities = new Lazy<IEnumerable<ExpensiveEntity>>(() => ExpensiveDataSource.GetEntities());
        _awayEntities = new Lazy<IEnumerable<ExpensiveEntity>>(() => ExpensiveDataSource.GetEntities());
    }
}
