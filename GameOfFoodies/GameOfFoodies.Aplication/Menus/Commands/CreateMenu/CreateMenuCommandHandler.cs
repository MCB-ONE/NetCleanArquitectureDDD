using ErrorOr;

using GameOfFoodies.Aplication.Common.Interfaces.Persistence;
using GameOfFoodies.Domain.HuespedAggregate.ValueObjects;
using GameOfFoodies.Domain.MenuAggregate;
using GameOfFoodies.Domain.MenuAggregate.Entities;

using MediatR;

namespace GameOfFoodies.Aplication.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{

    private readonly IMenuRepository _repository;

    public CreateMenuCommandHandler(IMenuRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        //TODO: Finish the real implementation
        await Task.CompletedTask;

        // Crear menu
        var menu = Menu.Create(
            huespedId: HuespedId.Create(request.HuespedId),
            nombre: request.Nombre,
            descripcion: request.Descripcion,
            secciones: request.Secciones.ConvertAll(seccion => SeccionMenu.Create(
                seccion.Nombre,
                seccion.Descripcion,
                seccion.Platos.ConvertAll(plato => PlatoMenu.Create(
                    plato.Nombre,
                    plato.Descripcion))
                )
            )   
        );

        // Persistir menu
        _repository.Add(menu);

        // Retornar menu
        return menu;
    }
}