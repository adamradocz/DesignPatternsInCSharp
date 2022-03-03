namespace DesignPatternsInCSharp.Structural.Composite.Conceptual;

/// <summary>
/// The Composite class
/// </summary>
public class BoxComposite : IProductComponent
{
    private readonly List<IProductComponent> _children = new();

    public void Add(IProductComponent component) => _children.Add(component);

    public bool Remove(IProductComponent component) => _children.Remove(component);

    public decimal CalculatePrice()
    {
        decimal total = 0;

        foreach (var child in _children)
        {
            total += child.CalculatePrice();
        }

        return total;
    }
}
