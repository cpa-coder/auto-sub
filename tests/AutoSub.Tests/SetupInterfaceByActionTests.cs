using AutoSub.Tests.Models;
using FluentAssertions;
using NSubstitute;

namespace AutoSub.Tests;

public class SetupInterfaceByActionTests
{
    //setup properties should return with the same value
    [Fact]
    public void setup_properties__should_return_with_the_same_value()
    {
        var autoSub = new AutoSub();
        autoSub.Setup<IDependency>(setup => setup
            .For(x => x.Value.Returns(1)));

        var instance = autoSub.Create<ConcreteClass>();
        instance.Dependency.Value.Should().Be(1);
    }

    //setup void methods should be called
    [Fact]
    public void setup_void_methods__should_receive_call()
    {
        var autoSub = new AutoSub();

        var instance = autoSub.Create<ConcreteClass>();
        instance.Dependency.SetValue(0);

        instance.Dependency.Received().SetValue(Arg.Any<int>());
    }

    //setup methods with return value should return with the same value
    [Fact]
    public void setup_methods_with_return_value__should_return_with_the_same_value()
    {
        var autoSub = new AutoSub();
        autoSub.Setup<IDependency>(setup => setup
            .For(x => x.GetValue().Returns(1)));

        var instance = autoSub.Create<ConcreteClass>();
        instance.Dependency.GetValue().Should().Be(1);
    }

    //setup async task methods should receive call
    [Fact]
    public async Task setup_async_task_methods__should_receive_call()
    {
        var autoSub = new AutoSub();

        var instance = autoSub.Create<ConcreteClass>();
        await instance.Dependency.SetValueAsync(0);

        await instance.Dependency.Received().SetValueAsync(Arg.Any<int>());
    }

    //setup async task methods with return value should return with the same value
    [Fact]
    public async Task setup_async_task_methods_with_return_value__should_return_with_the_same_value()
    {
        var autoSub = new AutoSub();
        autoSub.Setup<IDependency>(setup => setup
            .For(x => x.GetValueAsync().Returns(1)));

        var instance = autoSub.Create<ConcreteClass>();
        var result = await instance.Dependency.GetValueAsync();
        result.Should().Be(1);
    }

    //setup void methods to throw exception
    [Fact]
    public void setup_void_methods_to_throw_exception()
    {
        var autoSub = new AutoSub();
        autoSub.Setup<IDependency>(setup => setup
            .When(i => i.SetValue(Arg.Any<int>()))
            .Do(_ => throw new Exception()));

        var instance = autoSub.Create<ConcreteClass>();
        var act = () => instance.Dependency.SetValue(0);
        act.Should().Throw<Exception>();
    }

    //setup async task methods to throw exception
    [Fact]
    public async Task setup_async_task_methods_to_throw_exception()
    {
        var autoSub = new AutoSub();
        autoSub.Setup<IDependency>(setup => setup
            .For(i => i.SetValueAsync(Arg.Any<int>()).Returns(_ => throw new Exception())));

        var instance = autoSub.Create<ConcreteClass>();
        await Assert.ThrowsAsync<Exception>(() => instance.Dependency.SetValueAsync(0));
    }
    
    //setup non-void methods to throw exception
    [Fact]
    public void setup_non_void_methods_to_throw_exception()
    {
        var autoSub = new AutoSub();
        autoSub.Setup<IDependency>(setup => setup
            .For(i => i.GetValue().Returns(_ => throw new Exception())));

        var instance = autoSub.Create<ConcreteClass>();
        var act = () => instance.Dependency.GetValue();
        act.Should().Throw<Exception>();
    }
    
    //setup async task with result methods to throw exception
    [Fact]
    public async Task setup_async_task_with_result_methods_to_throw_exception()
    {
        var autoSub = new AutoSub();
        autoSub.Setup<IDependency>(setup => setup
            .For(i => i.GetValueAsync().Returns<int>(_ => throw new Exception())));

        var instance = autoSub.Create<ConcreteClass>();
        await Assert.ThrowsAsync<Exception>(() => instance.Dependency.GetValueAsync());
    }
}