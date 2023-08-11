using NSubstitute;
using NSubstitute.Core;

namespace AutoSub;

public interface ISetup<out T> where T : class
{
    ISetup<T> For(Func<T, ConfiguredCall> expression);
}

internal sealed class Setup<T> : ISetup<T> where T : class
{
    private readonly T _value;

    public ISetup<T> For(Func<T, ConfiguredCall> expression)
    {
        expression.Invoke(_value);
        return this;
    }

    public Setup(IDictionary<Type, object?> parameters)
    {
        var value = Substitute.For<T>();

        var exist = parameters.TryGetValue(typeof(T), out var val);
        if (exist) value = (T?) val;

        if (parameters.ContainsKey(typeof(T)))
            parameters[typeof(T)] = value;
        else
            parameters.Add(typeof(T), value);

        _value = value!;
    }
}