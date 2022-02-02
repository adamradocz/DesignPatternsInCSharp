namespace DesignPatternsInCSharp.Creational.Builder.Interfaces;

public interface IBuilder<T>
{
    void Reset();
    void SetName(string name = "");
    void SetValue(int value = 0);
    T Build();
}
