using ImpromptuInterface;
using System.Dynamic;

namespace DesignPatternsInCSharp.Structural.Proxy.DynamicProxy;

public class Log<T> : DynamicObject where T : class, new()
{
    private readonly T _subject;

    protected Log(T subject)
    {
        _subject = subject ?? throw new ArgumentNullException(nameof(subject));
    }

    public static I As<I>(T subject) where I : class => !typeof(I).IsInterface ? throw new ArgumentException("Must be an interface type") : new Log<T>(subject).ActLike<I>();

    public static I As<I>() where I : class => !typeof(I).IsInterface ? throw new ArgumentException("Must be an interface type") : new Log<T>(new T()).ActLike<I>();

    public override bool TryInvokeMember(InvokeMemberBinder binder, object?[]? args, out object? result)
    {
        try
        {
            Console.WriteLine($"Invoking {_subject.GetType().Name}.{binder.Name} with arguments [{string.Join(",", args)}]");
            result = _subject.GetType().GetMethod(binder.Name).Invoke(_subject, args);
            return true;
        }
        catch
        {
            result = null;
            return false;
        }
    }
}