using GameOfFoodies.Domain.Common.Models;
using GameOfFoodies.Domain.Menu.ValueObjects;

namespace GameOfFoodies.Domain.Menu.Entities;

public sealed class SeccionMenu : Entity<SeccionMenuId>
{
    private readonly List<PlatoMenu> _platos = new();
    public string Nombre { get; }
    public string Descripcion { get; }

    public IReadOnlyList<PlatoMenu> Platos => _platos.AsReadOnly();

    private SeccionMenu(SeccionMenuId seccionMenuId, string nombre, string descripcion)
    : base(seccionMenuId)
    {
        Nombre = nombre;
        Descripcion = descripcion;
    }

    public static SeccionMenu Create(string nombre, string descripcion){
        return new(SeccionMenuId.CreateUnique(), nombre, descripcion);
    }
    
}