using GameOfFoodies.Domain.CenaAggregate.ValueObjects;
using GameOfFoodies.Domain.Common.Models;
using GameOfFoodies.Domain.Common.ValueObjects;
using GameOfFoodies.Domain.HuespedAggregate.ValueObjects;
using GameOfFoodies.Domain.MenuAggregate.Entities;
using GameOfFoodies.Domain.MenuAggregate.ValueObjects;
using GameOfFoodies.Domain.ResenaAggregate.ValueObjects;

namespace GameOfFoodies.Domain.MenuAggregate;

public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<SeccionMenu> _secciones = new();
    private readonly List<CenaId> _cenaIds = new();
    private readonly List<ResenaId> _resenaMenuIds = new();
    public string Nombre {get; private set;}
    public string Descripcion {get; private set;}
    public PuntuacionMedia  PuntuacionMedia {get; private set;}
    public IReadOnlyList<SeccionMenu> Secciones => _secciones.AsReadOnly();
    public HuespedId HuespedId {get; private set;}
    public IReadOnlyList<CenaId> CenaIds => _cenaIds.AsReadOnly();
    public IReadOnlyList<ResenaId> ResenaMenuIds => _resenaMenuIds.AsReadOnly();
    public DateTime CreadoFechaHora {get; private set;}
    public DateTime ModificadoFechaHora {get; private set;}

    private Menu(
        MenuId menuId,
        HuespedId huespedId,
        string nombre,
        string descripcion,
        PuntuacionMedia puntuacionMedia,
        List<SeccionMenu>? secciones) : base(menuId)
    {
        HuespedId = huespedId;
        Nombre = nombre;
        Descripcion = descripcion;
        PuntuacionMedia = puntuacionMedia;
        _secciones = secciones;
    }

    public static Menu Create(
        HuespedId huespedId,
        string nombre,
        string descripcion,
        List<SeccionMenu>? secciones)
    {
        return new (
            MenuId.CreateUnique(),
            huespedId,
            nombre,
            descripcion,
            PuntuacionMedia.CreateNew(0),
            secciones
        );
    }

    #pragma warning disable CS8618
    private Menu()
    {
    }
    #pragma warning disable CS8618
}