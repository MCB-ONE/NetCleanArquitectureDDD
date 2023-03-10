using GameOfFoodies.Domain.Common.Models;

namespace GameOfFoodies.Domain.CenaAggregate.ValueObjects;

public sealed class CenaId : ValueObject
{
    public Guid Value {get; }

    private CenaId(Guid value)
    {
        Value = value;
    }

    public static CenaId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static CenaId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}