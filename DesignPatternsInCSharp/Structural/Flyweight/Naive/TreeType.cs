namespace DesignPatternsInCSharp.Structural.Flyweight.Naive;

public readonly record struct TreeType : IEquatable<TreeType>
{
    public string Name { get; init; }
    public string Hardness { get; init; }
    public int GrowTimeMonths { get; init; }

    public TreeType(string name, string hardness, int growTimeMonths)
    {
        Name = name;
        Hardness = hardness;
        GrowTimeMonths = growTimeMonths;
    }

    public void PlantTree(int height, int diameter, double x, double y)
    {
        //Do stuff here
    }

    #region IEquatable
    public bool Equals(TreeType other) =>
       Name == other.Name && Hardness == other.Hardness && GrowTimeMonths == other.GrowTimeMonths;

    public override int GetHashCode() => HashCode.Combine(Name, Hardness, GrowTimeMonths);
    #endregion
}