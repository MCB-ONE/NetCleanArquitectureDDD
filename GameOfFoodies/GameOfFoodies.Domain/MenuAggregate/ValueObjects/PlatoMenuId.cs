using GameOfFoodies.Domain.Common.Models;

namespace GameOfFoodies.Domain.MenuAggregate.ValueObjects;

public sealed class PlatoMenuId : ValueObject
{
    public Guid Value { get; }

    private PlatoMenuId(Guid value)
    {
        Value = value;
    }

    public static PlatoMenuId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public static PlatoMenuId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    private PlatoMenuId() { }
}