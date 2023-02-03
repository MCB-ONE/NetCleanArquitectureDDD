using GameOfFoodies.Domain.Common.Models;

namespace GameOfFoodies.Domain.Huesped.ValueObjects;

public sealed class HuespedId : ValueObject
{
    public Guid Value {get; }

    private HuespedId(Guid value)
    {
        Value = value;
    }

    public static HuespedId CreateUnique()
    {
        return new(Guid.NewGuid());
    }


    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}