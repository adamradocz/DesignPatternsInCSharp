namespace DesignPatternsInCSharp.Structural.Flyweight.Naive;

public class TreeTypeFactory
{
    //Naive/basic implementation of cache
    private readonly List<TreeType?> _treeTypes = new();

    public int CurrentCacheSize => _treeTypes.Count;

    public TreeType GetTreeType(string name, string hardness = "Normal", int growthTime = 12)
    {
        var type = _treeTypes.FirstOrDefault(treeType => treeType != null && treeType.Value.Name.Equals(name));
        if (type != null)
        {
            return type.Value;
        }

        TreeType newType = new(name, hardness, growthTime);
        _treeTypes.Add(newType);

        return newType;
    }
}
