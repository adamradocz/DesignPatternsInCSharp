using DesignPatternsInCSharp.Creational.Builder.Implementations;

namespace DesignPatternsInCSharp.Creational.Builder.Model;

public class ImmutableTestObject
{
    public ImmutableTestObject(ConcreteImmutableBuilder builder)
    {
        ObjectName = builder.Name;
        ObjectValue = builder.Value;
    }

    public string ObjectName { get; init; }

    public int ObjectValue { get; init; }
}
