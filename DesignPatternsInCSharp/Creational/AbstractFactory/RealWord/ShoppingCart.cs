using DesignPatternsInCSharp.Creational.AbstractFactory.RealWord.Interfaces;

namespace DesignPatternsInCSharp.Creational.AbstractFactory.RealWord;

public class ShoppingCart
{
    private readonly IFurnitureFactory _furnitureFactory;

    public ShoppingCart(IFurnitureFactory furnitureFactory)
    {
        _furnitureFactory = furnitureFactory ?? throw new ArgumentNullException(nameof(furnitureFactory));
    }

    public string PlaceOrder()
    {
        var chair = _furnitureFactory.CreateChair();
        var coffeeTable = _furnitureFactory.CreateCoffeeTable();
        var sofa = _furnitureFactory.CreateSofa();

        return $"Ordered: a {chair.Name} of {chair.Manufacturer}, {coffeeTable.Name} of {coffeeTable.Manufacturer} and {sofa.Name} of {sofa.Manufacturer}";
    }
}
