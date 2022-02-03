using DesignPatternsInCSharp.Creational.Builder.Interfaces;
using DesignPatternsInCSharp.Creational.Builder.Model;

namespace DesignPatternsInCSharp.Creational.Builder.Implementations;

public class ConcreteBuilder : IBuilder<TestObject>
{
    private TestObject _objectToBuild = new TestObject();

    public void Reset()
    {
        _objectToBuild = new TestObject();
    }

    public void SetName(in string name)
    {
        _objectToBuild.ObjectName = name;
    }
    public void SetValue(int value)
    {
        _objectToBuild.ObjectValue = value;
    }

    public TestObject Build()
    {
        return _objectToBuild;
    }
}
