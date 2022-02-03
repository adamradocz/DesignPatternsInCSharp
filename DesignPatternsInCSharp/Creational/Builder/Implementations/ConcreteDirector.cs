using DesignPatternsInCSharp.Creational.Builder.Interfaces;
using DesignPatternsInCSharp.Creational.Builder.Model;

namespace DesignPatternsInCSharp.Creational.Builder.Implementations;

public class ConcreteDirector
{
    public void MakeObject(IBuilder<TestObject> builder)
    {
        builder.Reset();
        builder.SetName();
        builder.SetValue();
    }

    public void MakeImmutableObject(IBuilder<ImmutableTestObject> builder)
    {
        builder.Reset();
        builder.SetName();
        builder.SetValue();
    }
}
