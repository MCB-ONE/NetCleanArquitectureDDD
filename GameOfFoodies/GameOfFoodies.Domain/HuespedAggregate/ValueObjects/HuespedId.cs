using GameOfFoodies.Domain.Common.Models;

namespace GameOfFoodies.Domain.HuespedAggregate.ValueObjects;

public sealed class HuespedId : ValueObject
{
    public Guid Value {get; private set; }

    private HuespedId(Guid value)
    {
        Value = value;
    }

    public static HuespedId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static HuespedId Create(Guid value)
    {
        return new(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    private HuespedId() { }
}