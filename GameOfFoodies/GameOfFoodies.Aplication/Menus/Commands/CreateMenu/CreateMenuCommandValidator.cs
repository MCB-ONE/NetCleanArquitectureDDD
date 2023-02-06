using FluentValidation;

namespace GameOfFoodies.Aplication.Menus.Commands.CreateMenu;

public class CreateMenuCommandValidator: AbstractValidator<CreateMenuCommand>
{
    public CreateMenuCommandValidator()
    {
        RuleFor(x => x.Nombre).NotEmpty();
        RuleFor(x => x.Descripcion).NotEmpty();
        RuleFor(x => x.Secciones).NotEmpty();
    }
}