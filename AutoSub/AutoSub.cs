namespace AutoSub;

public class AutoSub
{
    private readonly Dictionary<Type, object?> _parameters = new();
    private readonly Dictionary<string, (Type type, object? proxy)> _namedParameters = new();

    public AutoSub Setup<T>(Action<ISetup<T>> func) where T : class
    {
        func.Invoke(new Setup<T>(_parameters));
        return this;
    }

    public AutoSub Setup<T>(T value) where T : class
    {
        if (_parameters.ContainsKey(typeof(T)))
            _parameters[typeof(T)] = value;
        else
            _parameters.Add(typeof(T), value);

        return this;
    }
    
    public AutoSub Setup<T>(string parameterName, T? value) where T : struct
    {
        _namedParameters.Add(parameterName, (typeof(T), value));
        return this;
    }

    public AutoSub Setup<T>(string parameterName, T value) where T : class
    {
        _namedParameters.Add(parameterName, (typeof(T), value));
        return this;
    }

    public T Create<T>()
    {
        var constructor = typeof(T).GetConstructors().First();
        var parameters = constructor.GetParameters();
        var parameterValues = new object[parameters.Length];
        for (var i = 0; i < parameters.Length; i++)
        {
            var parameter = parameters[i];
            if (_parameters.TryGetValue(parameter.ParameterType, out var value))
            {
                if (value is not null)
                    parameterValues[i] = value;
            }
            else if (_namedParameters.TryGetValue(parameter.Name, out var namedValue))
            {
                parameterValues[i] = namedValue.proxy;
            }
            else if (parameter.ParameterType == typeof(string))
            {
                parameterValues[i] = string.Empty;
            }
            else
            {
                parameterValues[i] = Activator.CreateInstance(parameter.ParameterType)!;
            }
        }

        return (T) constructor.Invoke(parameterValues);
    }
}