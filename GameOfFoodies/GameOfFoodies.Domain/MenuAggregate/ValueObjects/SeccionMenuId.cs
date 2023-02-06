using GameOfFoodies.Domain.Common.Models;

namespace GameOfFoodies.Domain.MenuAggregate.ValueObjects;

public sealed class SeccionMenuId : ValueObject
{
    public Guid Value {get; private set; }

    private SeccionMenuId(Guid value)
    {
        Value = value;
    }

    public static SeccionMenuId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static SeccionMenuId Create(Guid value)
    {
        return new SeccionMenuId(value);
    }


    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    private SeccionMenuId() { }
}