using GameOfFoodies.Domain.Common.Models;
using GameOfFoodies.Domain.Resena.ValueObjects;

namespace GameOfFoodies.Domain.Resena;

public sealed class Resena : AggregateRoot<ResenaId>
{
    //TODO: Finish the entity modeling
    private Resena(ResenaId ResenaId) : base(ResenaId)
    {

    }

    
    public static Resena Create(string nombre, string descripcion){
        return new(ResenaId.CreateUnique());
    }
}