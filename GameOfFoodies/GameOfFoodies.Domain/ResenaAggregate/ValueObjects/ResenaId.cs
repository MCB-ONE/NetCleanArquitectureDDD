using GameOfFoodies.Domain.Common.Models;

namespace GameOfFoodies.Domain.ResenaAggregate.ValueObjects;

public sealed class ResenaId : ValueObject
{
    public Guid Value {get; private set; }

    private ResenaId(Guid value)
    {
        Value = value;
    }

    public static ResenaId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static ResenaId Create(Guid value)
    {
        return new (value);
    }


    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    private ResenaId() { }
}