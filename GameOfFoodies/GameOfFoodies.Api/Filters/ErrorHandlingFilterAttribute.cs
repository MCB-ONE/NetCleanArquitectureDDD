using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GameOfFoodies.Api.Filters;

// Filtor que se va a aplicar a todos los controladores.
//  -> Cuando se lance una excepcion HttpException no controlada se invocara el método OnException el cual sobreescribimos para acceder todas aquellas excepciones no controladas y devolver una respuesta personalizada.

public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {

        // Capturar la excepción producida
        var exception = context.Exception;

        context.Result = new ObjectResult(new { error = "Ha ocurrido un error al procesar su petición." })
        {
            StatusCode = StatusCodes.Status500InternalServerError
        };

        context.ExceptionHandled = true;
    }
}