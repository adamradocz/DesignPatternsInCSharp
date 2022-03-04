namespace DesignPatternsInCSharp.Structural.Flyweight.Naive;

public class ConcreteTree
{
    #region Unique State
    public int Height { get; set; }

    public int Diameter { get; set; }
    #endregion

    #region Flyweight
    public TreeType TreeType { get; set; }
    #endregion

    public ConcreteTree(int height, int diameter, TreeType treeType)
    {
        Height = height;
        Diameter = diameter;
        TreeType = treeType;
    }

    public void PlantTree(double x, double y)
    {
        TreeType.PlantTree(Height, Diameter, x, y);
    }
}
