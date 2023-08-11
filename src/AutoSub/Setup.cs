using NSubstitute;
using NSubstitute.Core;

namespace AutoSub;

/// <summary>
///     Setup <see cref="T" /> substitute using NSubstitute.
/// </summary>
/// <typeparam name="T">The type to be substituted with a proxy object</typeparam>
public interface ISetup<T> where T : class
{
    /// <summary>
    ///     Configure property or method of <see cref="T" /> proxy object.
    /// </summary>
    /// <param name="expression">The method to setup a property or method</param>
    /// <returns>
    ///     <see cref="ISetup{T}" />
    /// </returns>
    ISetup<T> For(Func<T, ConfiguredCall> expression);

    /// <summary>
    ///     Perform an action when this member is called.
    /// </summary>
    /// <param name="call"></param>
    /// <returns></returns>
    WhenCalled<T> When(Action<T> call);
}

internal sealed class Setup<T> : ISetup<T> where T : class
{
    private readonly T _value;

    public ISetup<T> For(Func<T, ConfiguredCall> expression)
    {
        expression.Invoke(_value);
        return this;
    }

    public WhenCalled<T> When(Action<T> call) => _value.When(call);

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