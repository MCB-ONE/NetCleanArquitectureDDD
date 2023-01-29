using FluentValidation;

namespace GameOfFoodies.Aplication.Auth.Commands.Registro;

public class RegistroCommandValidator: AbstractValidator<RegistroCommand>
{
    public RegistroCommandValidator()
    {
        RuleFor(x => x.Nombre).NotEmpty();
        RuleFor(x => x.Apellido).NotEmpty();
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
    }
    
}