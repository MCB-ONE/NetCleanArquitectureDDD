using GameOfFoodies.Domain.Common.Models;
using GameOfFoodies.Domain.MenuAggregate.ValueObjects;

namespace GameOfFoodies.Domain.MenuAggregate.Entities;

public sealed class PlatoMenu : Entity<PlatoMenuId>
{
    public string Nombre { get; }
    public string Descripcion { get; }

    private PlatoMenu(PlatoMenuId platoMenuId, string nombre, string descripcion)
    : base(platoMenuId)
    {
        Nombre = nombre;
        Descripcion = descripcion;
    }

    public static PlatoMenu Create(string nombre, string descripcion){
        return new(PlatoMenuId.CreateUnique(), nombre, descripcion);
    }
}