namespace AutoSub.Tests.Models;

public class ConcreteClass
{
    public IDependency Dependency { get; }

    public ConcreteClass(IDependency dependency)
    {
        Dependency = dependency;
    }
}