using GameOfFoodies.Domain.Common.Models;
using GameOfFoodies.Domain.MenuAggregate.ValueObjects;

namespace GameOfFoodies.Domain.MenuAggregate.Entities;

public sealed class PlatoMenu : Entity<PlatoMenuId>
{
    public string Nombre { get; private set; }
    public string Descripcion { get; private set; }

    private PlatoMenu(PlatoMenuId platoMenuId, string nombre, string descripcion)
    : base(platoMenuId)
    {
        Nombre = nombre;
        Descripcion = descripcion;
    }

    public static PlatoMenu Create(string nombre, string descripcion){
        return new(PlatoMenuId.CreateUnique(), nombre, descripcion);
    }

    #pragma warning disable CS8618
    private PlatoMenu()
    {
    }
    #pragma warning disable CS8618
}