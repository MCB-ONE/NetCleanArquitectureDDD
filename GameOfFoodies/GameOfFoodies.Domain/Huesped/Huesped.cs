using GameOfFoodies.Domain.Common.Models;
using GameOfFoodies.Domain.Huesped.ValueObjects;

namespace GameOfFoodies.Domain.Huesped;

public sealed class Huesped : AggregateRoot<HuespedId>
{
    //TODO: Finish the entity modeling
    private Huesped(HuespedId huespedId) : base(huespedId)
    {

    }

    
    public static Huesped Create(string nombre, string descripcion){
        return new(HuespedId.CreateUnique());
    }
}