using System.Collections.ObjectModel;
using FluentAssertions;

namespace AutoSub.Tests;

public class CollectionParameterTests
{
    private class CollectionType<T>
    {
        public T Value { get; }

        public CollectionType(T value)
        {
            Value = value;
        }
    }

    [Fact]
    public void array__on_default__instance_value_should_should_be_empty()
    {
        var factory = new SubFactory();

        var instance = factory.Create<CollectionType<int[]>>();
        instance.Value.Should().BeEmpty();
    }

    [Fact]
    public void array__when_set_to_1__instance_value_should_should_be_1()
    {
        var factory = new SubFactory();
        factory.Setup(new[] { 1 });

        var instance = factory.Create<CollectionType<int[]>>();
        instance.Value.Should().BeEquivalentTo(new[] { 1 });
    }

    [Fact]
    public void list__on_default__instance_value_should_should_be_empty()
    {
        var factory = new SubFactory();

        var instance = factory.Create<CollectionType<List<int>>>();
        instance.Value.Should().BeEmpty();
    }

    [Fact]
    public void list__when_set_to_1__instance_value_should_should_be_1()
    {
        var factory = new SubFactory();
        factory.Setup(new List<int> { 1 });

        var instance = factory.Create<CollectionType<List<int>>>();
        instance.Value.Should().BeEquivalentTo(new List<int> { 1 });
    }

    [Fact]
    public void observable_collection__on_default__instance_value_should_should_be_empty()
    {
        var factory = new SubFactory();

        var instance = factory.Create<CollectionType<ObservableCollection<int>>>();
        instance.Value.Should().BeEmpty();
    }

    [Fact]
    public void observable_collection__when_set_to_1__instance_value_should_should_be_1()
    {
        var factory = new SubFactory();
        factory.Setup(new ObservableCollection<int> { 1 });

        var instance = factory.Create<CollectionType<ObservableCollection<int>>>();
        instance.Value.Should().BeEquivalentTo(new ObservableCollection<int> { 1 });
    }

    [Fact]
    public void dictionary__on_default__instance_value_should_should_be_empty()
    {
        var factory = new SubFactory();

        var instance = factory.Create<CollectionType<Dictionary<int, string>>>();
        instance.Value.Should().BeEmpty();
    }

    [Fact]
    public void dictionary__when_set_to_1__instance_value_should_should_be_1()
    {
        var factory = new SubFactory();
        factory.Setup(new Dictionary<int, string> { { 1, "1" } });

        var instance = factory.Create<CollectionType<Dictionary<int, string>>>();
        instance.Value.Should().BeEquivalentTo(new Dictionary<int, string> { { 1, "1" } });
    }

    [Fact]
    public void hash_set__on_default__instance_value_should_should_be_empty()
    {
        var factory = new SubFactory();

        var instance = factory.Create<CollectionType<HashSet<int>>>();
        instance.Value.Should().BeEmpty();
    }

    [Fact]
    public void hash_set__when_set_to_1__instance_value_should_should_be_1()
    {
        var factory = new SubFactory();
        factory.Setup(new HashSet<int> { 1 });

        var instance = factory.Create<CollectionType<HashSet<int>>>();
        instance.Value.Should().BeEquivalentTo(new HashSet<int> { 1 });
    }
}