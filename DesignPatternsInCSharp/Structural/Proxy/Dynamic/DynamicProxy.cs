using ImpromptuInterface;
using Microsoft.Extensions.Logging;
using System.Dynamic;

namespace DesignPatternsInCSharp.Structural.Proxy.Dynamic;

public class Log<T> : DynamicObject where T : class, new()
{
    private readonly T _subject;
    private readonly ILogger<T> _logger;

    public Log(T subject, ILogger<T> logger)
    {
        _subject = subject ?? throw new ArgumentNullException(nameof(subject));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public static I As<I>(T subject, ILogger<T> logger) where I : class => !typeof(I).IsInterface ? throw new ArgumentException("Must be an interface type") : new Log<T>(subject, logger).ActLike<I>();

    public static I As<I>(ILogger<T> logger) where I : class => !typeof(I).IsInterface ? throw new ArgumentException("Must be an interface type") : new Log<T>(new T(), logger).ActLike<I>();

    public override bool TryInvokeMember(InvokeMemberBinder binder, object?[]? args, out object? result)
    {
        try
        {
            _logger.LogTrace($"Invoking {_subject.GetType().Name}.{binder.Name} with arguments [{string.Join(",", args)}]");
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