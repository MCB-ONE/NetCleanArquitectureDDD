using GameOfFoodies.Domain.Common.Models;

namespace GameOfFoodies.Domain.Cena.ValueObjects;

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


    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}