using DesignPatternsInCSharp.Creational.Builder.Interfaces;
using DesignPatternsInCSharp.Creational.Builder.Model;

namespace DesignPatternsInCSharp.Creational.Builder.Implementations;

public class ConcreteImmutableBuilder : IBuilder<ImmutableTestObject>
{
    public string Name { get; private set; } = string.Empty;
    public int Value { get; private set; } = 0;

    public void Reset()
    {
        Name = string.Empty;
        Value = 0;
    }

    public void SetName(in string name)
    {
        Name = name;
    }
    public void SetValue(int value)
    {
        Value = value;
    }

    public ImmutableTestObject Build()
    {
        return new ImmutableTestObject(this);
    }
}
