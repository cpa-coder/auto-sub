using FluentAssertions;

namespace AutoSub.Tests;

public class BasicTypeParameterTests
{
    private class BasicType<T>
    {
        public T Value { get; }

        public BasicType(T value)
        {
            Value = value;
        }
    }

    [Fact]
    public void bool__on_default__instance_value_should_should_be_false()
    {
        var factory = new SubFactory();

        var instance = factory.Create<BasicType<bool>>();
        instance.Value.Should().BeFalse();
    }

    [Fact]
    public void bool__when_set_to_true__instance_value_should_should_be_true()
    {
        var factory = new SubFactory();
        factory.Setup<bool>(true);

        var instance = factory.Create<BasicType<bool>>();
        instance.Value.Should().BeTrue();
    }

    [Fact]
    public void byte__on_default__instance_value_should_should_be_0()
    {
        var factory = new SubFactory();

        var instance = factory.Create<BasicType<byte>>();
        instance.Value.Should().Be(0);
    }

    [Fact]
    public void byte__when_set_to_1__instance_value_should_should_be_1()
    {
        var factory = new SubFactory();
        factory.Setup<byte>(1);

        var instance = factory.Create<BasicType<byte>>();
        instance.Value.Should().Be(1);
    }

    [Fact]
    public void sbyte__on_default__instance_value_should_should_be_0()
    {
        var factory = new SubFactory();

        var instance = factory.Create<BasicType<sbyte>>();
        instance.Value.Should().Be(0);
    }

    [Fact]
    public void sbyte__when_set_to_1__instance_value_should_should_be_1()
    {
        var factory = new SubFactory();
        factory.Setup<sbyte>(1);

        var instance = factory.Create<BasicType<sbyte>>();
        instance.Value.Should().Be(1);
    }

    [Fact]
    public void short__on_default__instance_value_should_should_be_0()
    {
        var factory = new SubFactory();

        var instance = factory.Create<BasicType<short>>();
        instance.Value.Should().Be(0);
    }

    [Fact]
    public void short__when_set_to_1__instance_value_should_should_be_1()
    {
        var factory = new SubFactory();
        factory.Setup<short>(1);

        var instance = factory.Create<BasicType<short>>();
        instance.Value.Should().Be(1);
    }

    [Fact]
    public void ushort__on_default__instance_value_should_should_be_0()
    {
        var factory = new SubFactory();

        var instance = factory.Create<BasicType<ushort>>();
        instance.Value.Should().Be(0);
    }

    [Fact]
    public void ushort__when_set_to_1__instance_value_should_should_be_1()
    {
        var factory = new SubFactory();
        factory.Setup<ushort>(1);

        var instance = factory.Create<BasicType<ushort>>();
        instance.Value.Should().Be(1);
    }

    [Fact]
    public void int__on_default__instance_value_should_should_be_0()
    {
        var factory = new SubFactory();

        var instance = factory.Create<BasicType<int>>();
        instance.Value.Should().Be(0);
    }

    [Fact]
    public void int__when_set_to_1__instance_value_should_should_be_1()
    {
        var factory = new SubFactory();
        factory.Setup<int>(1);

        var instance = factory.Create<BasicType<int>>();
        instance.Value.Should().Be(1);
    }

    [Fact]
    public void uint__on_default__instance_value_should_should_be_0()
    {
        var factory = new SubFactory();

        var instance = factory.Create<BasicType<uint>>();
        instance.Value.Should().Be(0);
    }

    [Fact]
    public void uint__when_set_to_1__instance_value_should_should_be_1()
    {
        var factory = new SubFactory();
        factory.Setup<uint>(1);

        var instance = factory.Create<BasicType<uint>>();
        instance.Value.Should().Be(1);
    }

    [Fact]
    public void long__on_default__instance_value_should_should_be_0()
    {
        var factory = new SubFactory();

        var instance = factory.Create<BasicType<long>>();
        instance.Value.Should().Be(0);
    }

    [Fact]
    public void long__when_set_to_1__instance_value_should_should_be_1()
    {
        var factory = new SubFactory();
        factory.Setup<long>(1);

        var instance = factory.Create<BasicType<long>>();
        instance.Value.Should().Be(1);
    }

    [Fact]
    public void ulong__on_default__instance_value_should_be_0()
    {
        var factory = new SubFactory();

        var instance = factory.Create<BasicType<ulong>>();
        instance.Value.Should().Be(0);
    }

    [Fact]
    public void ulong__when_set_to_1__instance_value_should_be_1()
    {
        var factory = new SubFactory();
        factory.Setup<ulong>(1);

        var instance = factory.Create<BasicType<ulong>>();
        instance.Value.Should().Be(1);
    }

    [Fact]
    public void float__on_default__instance_value_should_be_0()
    {
        var factory = new SubFactory();

        var instance = factory.Create<BasicType<float>>();
        instance.Value.Should().Be(0);
    }

    [Fact]
    public void float__when_set_to_1__instance_value_should_be_1()
    {
        var factory = new SubFactory();
        factory.Setup<float>(1);

        var instance = factory.Create<BasicType<float>>();
        instance.Value.Should().Be(1);
    }

    [Fact]
    public void double__on_default__instance_value_should_be_0()
    {
        var factory = new SubFactory();

        var instance = factory.Create<BasicType<double>>();
        instance.Value.Should().Be(0);
    }

    [Fact]
    public void double__when_set_to_1__instance_value_should_be_1()
    {
        var factory = new SubFactory();
        factory.Setup<double>(1);

        var instance = factory.Create<BasicType<double>>();
        instance.Value.Should().Be(1);
    }

    [Fact]
    public void decimal__on_default__instance_value_should_be_0()
    {
        var factory = new SubFactory();

        var instance = factory.Create<BasicType<decimal>>();
        instance.Value.Should().Be(0);
    }

    [Fact]
    public void decimal__when_set_to_1__instance_value_should_be_1()
    {
        var factory = new SubFactory();
        factory.Setup<decimal>(1);

        var instance = factory.Create<BasicType<decimal>>();
        instance.Value.Should().Be(1);
    }

    [Fact]
    public void char__on_default__instance_value_should_be_0()
    {
        var factory = new SubFactory();

        var instance = factory.Create<BasicType<char>>();
        instance.Value.Should().Be('\0');
    }

    [Fact]
    public void char__when_set_to_1__instance_value_should_be_1()
    {
        var factory = new SubFactory();
        factory.Setup<char>('1');

        var instance = factory.Create<BasicType<char>>();
        instance.Value.Should().Be('1');
    }

    [Fact]
    public void string__on_default__instance_value_should_be_null()
    {
        var factory = new SubFactory();

        var instance = factory.Create<BasicType<string>>();
        instance.Value.Should().BeNull();
    }

    [Fact]
    public void string__when_set_to_1__instance_value_should_be_1()
    {
        var factory = new SubFactory();
        factory.Setup<string>("1");

        var instance = factory.Create<BasicType<string>>();
        instance.Value.Should().Be("1");
    }

    [Fact]
    public void date_time__on_default__instance_value_should_be_default()
    {
        var factory = new SubFactory();

        var instance = factory.Create<BasicType<DateTime>>();
        instance.Value.Should().Be(default);
    }

    [Fact]
    public void date_time__when_value_is_set__should_return_instance_with_same_value()
    {
        var factory = new SubFactory();
        factory.Setup<DateTime>(DateTime.Today);

        var instance = factory.Create<BasicType<DateTime>>();
        instance.Value.Should().Be(DateTime.Today);
    }

    [Fact]
    public void time_span__on_default__instance_value_should_be_default()
    {
        var factory = new SubFactory();

        var instance = factory.Create<BasicType<TimeSpan>>();
        instance.Value.Should().Be(default);
    }

    [Fact]
    public void time_span__when_value_is_set__should_return_instance_with_same_value()
    {
        var factory = new SubFactory();
        factory.Setup<TimeSpan>(TimeSpan.FromDays(1));

        var instance = factory.Create<BasicType<TimeSpan>>();
        instance.Value.Should().Be(TimeSpan.FromDays(1));
    }

    private enum CustomEnum
    {
        First,
        Second
    }

    [Fact]
    public void enum__on_default__instance_value_should_be_null()
    {
        var factory = new SubFactory();

        var instance = factory.Create<BasicType<CustomEnum>>();
        instance.Value.Should().Be(CustomEnum.First);
    }

    [Fact]
    public void enum__when_value_is_set__should_return_instance_with_same_value()
    {
        var factory = new SubFactory();
        factory.Setup<CustomEnum>(CustomEnum.Second);

        var instance = factory.Create<BasicType<CustomEnum>>();
        instance.Value.Should().Be(CustomEnum.Second);
    }
}