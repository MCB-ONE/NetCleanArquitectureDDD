using ErrorOr;
using FluentValidation;
using GameOfFoodies.Aplication.Auth.Commands.Registro;
using GameOfFoodies.Aplication.Auth.Common;
using MediatR;

namespace GameOfFoodies.Aplication.Common.Behavior;

// Pipeline para validar nuestras solicitudes de MediatR utilizando Fluid Validation.
// Método genérico para validar cualquier request que provenga de mediator: 
// => TRequest ==> Cualquier mediator request (petición de mediatR)
// => TResponse ==> Cualquier respuesta que esperemos de dicha petición
public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
    where TRequest: IRequest<TResponse>
    where TResponse: IErrorOr
{
    private readonly IValidator<TRequest>? _validator;

    // IValidator<TRequest>? validator = null ==> (Validacón opcional) 0 o 1 validaciones para cada petición
    // IMPORTANTE:  especificar validator = null en el constructor si queremos que la validación sea opcional si no lanza una excepción
    public ValidationBehavior(IValidator<TRequest>? validator = null)
    {
        _validator = validator;
    }
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if(_validator is null){
            return await next();
        }
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if( validationResult.IsValid)
        {
            return await next();
        }
        
        var errors = validationResult.Errors
        .ConvertAll(validationFailure => Error.Validation(
            validationFailure.PropertyName,
            validationFailure.ErrorMessage));

        // (dynamic) Verifica en tiempo de ejecución que se peuda convertir la lista de errores en un error o en un objeto si no devolverá una excepción en tiempo de ejecucón
        return (dynamic)errors;
    }
}