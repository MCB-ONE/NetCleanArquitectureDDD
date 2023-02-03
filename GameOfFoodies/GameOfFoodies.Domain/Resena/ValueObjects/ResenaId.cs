using GameOfFoodies.Domain.Common.Models;

namespace GameOfFoodies.Domain.Resena.ValueObjects;

public sealed class ResenaId : ValueObject
{
    public Guid Value {get; }

    private ResenaId(Guid value)
    {
        Value = value;
    }

    public static ResenaId CreateUnique()
    {
        return new(Guid.NewGuid());
    }


    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}