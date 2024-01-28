namespace TradingSimulator.Infrastructure.Domain;

public interface IValueObject
{
}

public interface IValueObject<T> : IValueObject, IEquatable<T> where T : IValueObject<T>
{
    //bool SameValueAs(T other);
}