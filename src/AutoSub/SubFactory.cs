using System.Reflection;
using NSubstitute;

namespace AutoSub;

/// <summary>
///     Allows you to configure object dependencies with mocks, fakes, or stubs for ease of testing system under test.
/// </summary>
public class SubFactory
{
    private readonly Dictionary<Type, object?> _parameters = new();
    private readonly Dictionary<string, (Type type, object? proxy)> _namedParameters = new();

    /// <summary>
    ///     Setup <see cref="T" /> with configured properties and methods.
    /// </summary>
    /// <param name="func">The function to configure properties and methods of <see cref="T" />.</param>
    /// <typeparam name="T">Type type of parameter you want to configure.</typeparam>
    /// <returns><see cref="SubFactory" /> for a fluent syntax.</returns>
    public SubFactory Setup<T>(Action<ISetup<T>> func) where T : class
    {
        func.Invoke(new Setup<T>(_parameters));
        return this;
    }

    /// <summary>
    ///     Setup <see cref="T" /> with predefined object.
    /// </summary>
    /// <param name="value">The value which substitutes <see cref="T" />.</param>
    /// <typeparam name="T">Type type of parameter you want to configure.</typeparam>
    /// <returns><see cref="SubFactory" /> for a fluent syntax.</returns>
    /// <tips>Setup with specified parameter name overrides this method.</tips>
    public SubFactory Setup<T>(T? value) where T : struct
    {
        if (_parameters.ContainsKey(typeof(T)))
            _parameters[typeof(T)] = value;
        else
            _parameters.Add(typeof(T), value);

        return this;
    }

    /// <summary>
    ///     Setup <see cref="T" /> with predefined object.
    /// </summary>
    /// <param name="value">The value which substitutes <see cref="T" />.</param>
    /// <typeparam name="T">Type type of parameter you want to configure.</typeparam>
    /// <returns><see cref="SubFactory" /> for a fluent syntax.</returns>
    /// <tips>Setup with specified parameter name overrides this method.</tips>
    public SubFactory Setup<T>(T value) where T : class
    {
        if (_parameters.ContainsKey(typeof(T)))
            _parameters[typeof(T)] = value;
        else
            _parameters.Add(typeof(T), value);

        return this;
    }

    /// <summary>
    ///     Setup <see cref="T" /> with predefined object.
    /// </summary>
    /// <param name="parameterName">The parameter name specified in the constructor</param>
    /// <param name="value">The value which substitutes <see cref="T" />.</param>
    /// <typeparam name="T">Type type of parameter you want to configure.</typeparam>
    /// <returns><see cref="SubFactory" /> for a fluent syntax.</returns>
    /// <reminder>Make sure to match the corresponding parameter name in the constructor</reminder>
    public SubFactory Setup<T>(string parameterName, T? value) where T : struct
    {
        _namedParameters.Add(parameterName, (typeof(T), value));
        return this;
    }

    /// <summary>
    ///     Setup <see cref="T" /> with predefined object.
    /// </summary>
    /// <param name="parameterName">The parameter name specified in the constructor</param>
    /// <param name="value">The value which substitutes <see cref="T" />.</param>
    /// <typeparam name="T">Type type of parameter you want to configure.</typeparam>
    /// <returns><see cref="SubFactory" /> for a fluent syntax.</returns>
    /// <reminder>Make sure to match the corresponding parameter name in the constructor</reminder>
    public SubFactory Setup<T>(string parameterName, T value) where T : class
    {
        _namedParameters.Add(parameterName, (typeof(T), value));
        return this;
    }

    /// <summary>
    ///     Creates an object of type <see cref="T" /> based on the preconfigured properties and methods
    /// </summary>
    /// <param name="index">The constructor index to be use to specify the parameters to resolve when creating an object.</param>
    /// <typeparam name="T">The type of class you want to instantiate.</typeparam>
    /// <returns>The actual object</returns>
    /// <exception cref="IndexOutOfRangeException">Throws when the constructor index is out of range.</exception>
    /// <tips>The order of constructors written in a class matters, when specifying constructor index.</tips>
    public T Create<T>(int index = 0) where T : class
    {
        var constructors = typeof(T).GetConstructors();

        if (constructors.Length < index + 1 || index < 0)
            throw new IndexOutOfRangeException(
                $"Cannot find constructor with index: {index} in type: {typeof(T).FullName}.");

        var constructor = constructors[index];

        var parameters = constructor.GetParameters();
        var parameterValues = new object[parameters.Length];
        for (var i = 0; i < parameters.Length; i++)
        {
            var parameter = parameters[i];

            var instance = CreateParameterInstance(parameter);
            if (instance is not null)
                parameterValues[i] = instance;
        }

        return (T) constructor.Invoke(parameterValues);
    }

    private object? CreateParameterInstance(ParameterInfo parameter)
    {
        var type = parameter.ParameterType;
        var name = parameter.Name;

        var inParameters = _parameters.TryGetValue(type, out var value);
        var inNamedParameters = _namedParameters.TryGetValue(name, out var namedValue);

        if (inParameters)
        {
            if (inNamedParameters) return namedValue.proxy;
            if (value is not null) return value;
        }

        if (inNamedParameters) return namedValue.proxy;

        if (type == typeof(string)) return null;

        if (type.IsPrimitive)
            return Activator.CreateInstance(type);

        if (type.IsValueType) return default;

        if (type.IsArray)
            return Array.CreateInstance(type.GetElementType()!, 0);

        return Substitute.For(new[] { type }, null);
    }
}