namespace DesignPatternsInCSharp.Structural.Proxy.VirtualProxy;

public static class ExpensiveDataSource
{
    public static List<ExpensiveEntity> GetEntities()
    {
        var list = new List<ExpensiveEntity>();
        for (int i = 0; i < 10; i++)
        {
            list.Add(new ExpensiveEntity { Id = i });
        }  
        return list;
    }
}
