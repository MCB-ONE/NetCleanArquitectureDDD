using GameOfFoodies.Domain.CenaAggregate.ValueObjects;
using GameOfFoodies.Domain.Common.Models;
using GameOfFoodies.Domain.HuespedAggregate.ValueObjects;
using GameOfFoodies.Domain.MenuAggregate.Entities;
using GameOfFoodies.Domain.MenuAggregate.ValueObjects;
using GameOfFoodies.Domain.ResenaAggregate.ValueObjects;

namespace GameOfFoodies.Domain.MenuAggregate;

public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<SeccionMenu> _secciones = new();
    private readonly List<CenaId> _cenaIds = new();
    private readonly List<ResenaId> _resenaIds = new();
    public string Nombre {get;}
    public string Descripcion {get;}
    public float  PuntuacionMedia {get;}
    public IReadOnlyList<SeccionMenu> Secciones => _secciones.AsReadOnly();
    public HuespedId HuespedId {get;}
    public IReadOnlyList<CenaId> CenaIds => _cenaIds.AsReadOnly();
    public IReadOnlyList<ResenaId> ResenaIds => _resenaIds.AsReadOnly();
    public DateTime CreadoFechaHora {get;}
    public DateTime ModificadoFechaHora {get;}

    private Menu(
        MenuId menuId,
        string nombre,
        string descripcion,
        HuespedId huespedId,
        DateTime creadoFechaHora,
        DateTime modificadoFechaHora): base(menuId)
    {
        Nombre = nombre;
        Descripcion = descripcion;
        HuespedId = huespedId;
        CreadoFechaHora = creadoFechaHora;
        ModificadoFechaHora = modificadoFechaHora;
    }

    public static Menu Create(
        string nombre,
        string descripcion,
        HuespedId huespedId)
    {
        return new (
            MenuId.CreateUnique(),
            nombre,
            descripcion,
            huespedId,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }

}