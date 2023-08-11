namespace AutoSub.Tests.Models;

public interface IDependency
{
    int Value { get; set; }
    void SetValue(int value);
    int GetValue();
    Task SetValueAsync(int value);
    Task<int> GetValueAsync();
}