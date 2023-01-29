using ErrorOr;
using FluentValidation;
using GameOfFoodies.Aplication.Auth.Commands.Registro;
using GameOfFoodies.Aplication.Auth.Common;
using MediatR;

namespace GameOfFoodies.Aplication.Common.Behavior;

// Pipeline para validar nuestras solicitudes de MediatR utilizando Fluid Validation.
public class ValidateRegistroCommandBehavior : IPipelineBehavior<RegistroCommand, ErrorOr<AuthResult>>
{
    private readonly IValidator<RegistroCommand> _validator;

    public ValidateRegistroCommandBehavior(IValidator<RegistroCommand> validator)
    {
        _validator = validator;
    }


    // RegistroCommand request: solicitud enviada que podemos manipular o loggear antes de llamar al delegado (next)
    // RequestHandlerDelegate<ErrorOr<AuthResult>> next: delegado que eventualmente invocará a nuestro commandHandler y devuelve la respuesta que podremos manipular
    public async Task<ErrorOr<AuthResult>> Handle(
        RegistroCommand request,
        RequestHandlerDelegate<ErrorOr<AuthResult>> next,
        CancellationToken cancellationToken)
    {
        // Lógica que se va a ejecutar antes de invocar el manejador
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        // Si la validación es correcta invocamos al commandHandler
        if( validationResult.IsValid)
        {
            return await next();
        }

        // Si hay algún error de validación recogemos los errores y los añadimos a la nuesta lista de errores de la respuesta
        // var errors = validationResult.Errors
        // .Select(validationFailure => Error.Validation(
        //     validationFailure.PropertyName,
        //     validationFailure.ErrorMessage))
        // .ToList();
        // Refactorizado:
        var errors = validationResult.Errors
        .ConvertAll(validationFailure => Error.Validation(
            validationFailure.PropertyName,
            validationFailure.ErrorMessage));

        // Lógica que se va a ejecutar después de invocar el manejador

        return errors;
    }
}