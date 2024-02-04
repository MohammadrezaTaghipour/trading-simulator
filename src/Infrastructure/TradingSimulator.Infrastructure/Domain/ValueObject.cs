namespace TradingSimulator.Infrastructure.Domain;

public abstract class ValueObject<T> : IValueObject<T> where T : class, IValueObject<T>
{
    // public abstract bool SameValueAs(T other);

    public abstract override int GetHashCode();

    protected virtual bool AcceptDifferentTypesInEquality => false;

    public bool Equals(T other)
    {
        // return (object) other != null && (this.AcceptDifferentTypesInEquality || !(this.GetType() != other.GetType())) && this.SameValueAs(other);
        return (object) other != null && (this.AcceptDifferentTypesInEquality || !(this.GetType() != other.GetType()));
    }

    public override bool Equals(object valueObject) => this.Equals(valueObject as T);

    public static bool operator ==(ValueObject<T> left, ValueObject<T> right)
    {
        if ((object) left == (object) right)
            return true;
        return (object) left != null && (object) right != null && left.Equals((object) right);
    }

    public static bool operator ==(ValueObject<T> left, object right)
    {
        if ((object) left == right)
            return true;
        return (object) left != null && right != null && left.Equals(right);
    }

    public static bool operator ==(object left, ValueObject<T> right)
    {
        if (left == (object) right)
            return true;
        return left != null && (object) right != null && left.Equals((object) right);
    }

    public static bool operator !=(object left, ValueObject<T> right) => !(left == right);

    public static bool operator !=(ValueObject<T> left, object right) => !(left == right);

    public static bool operator !=(ValueObject<T> left, ValueObject<T> right) => !(left == right);
}