using GameOfFoodies.Domain.Cena.ValueObjects;
using GameOfFoodies.Domain.Common.Models;
namespace GameOfFoodies.Domain.Cena;

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