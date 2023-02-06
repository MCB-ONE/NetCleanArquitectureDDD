using ErrorOr;

using GameOfFoodies.Domain.MenuAggregate;

using MediatR;

namespace GameOfFoodies.Aplication.Menus.Commands.CreateMenu;

public record CreateMenuCommand(
    Guid  HuespedId,
    string Nombre,
    string Descripcion,
    List<SeccionMenuCommand> Secciones
) : IRequest<ErrorOr<Menu>>;

public record SeccionMenuCommand(
    string Nombre,
    string Descripcion,
    List<PlatoMenuCommand> Platos
);

public record PlatoMenuCommand(
    string Nombre,
    string Descripcion
);
