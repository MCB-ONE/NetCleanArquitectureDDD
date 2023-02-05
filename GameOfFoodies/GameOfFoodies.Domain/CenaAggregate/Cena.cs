using GameOfFoodies.Domain.CenaAggregate.ValueObjects;
using GameOfFoodies.Domain.Common.Models;
namespace GameOfFoodies.Domain.CenaAggregate;

public sealed class Cena : AggregateRoot<CenaId>
{
    //TODO: Finish the entity modeling
    private Cena(CenaId CenaId) : base(CenaId)
    {

    }

    
    public static Cena Create(string nombre, string descripcion){
        return new(CenaId.CreateUnique());
    }
}