using GameOfFoodies.Domain.Common.Models;
using GameOfFoodies.Domain.MenuAggregate.ValueObjects;

namespace GameOfFoodies.Domain.MenuAggregate.Entities;

public sealed class SeccionMenu : Entity<SeccionMenuId>
{
    private readonly List<PlatoMenu> _platos = new();
    public string Nombre { get; private set; }
    public string Descripcion { get; private set; }

    public IReadOnlyList<PlatoMenu> Platos => _platos.AsReadOnly();

    private SeccionMenu(SeccionMenuId seccionMenuId, string nombre, string descripcion, List<PlatoMenu> platos)
    : base(seccionMenuId)
    {
        Nombre = nombre;
        Descripcion = descripcion;
        _platos = platos;
    }

    public static SeccionMenu Create(string nombre, string descripcion, List<PlatoMenu> platos){
        return new(SeccionMenuId.CreateUnique(), nombre, descripcion,platos);
    }

    #pragma warning disable CS8618
    private SeccionMenu()
    {
    }
    #pragma warning disable CS8618
    
}