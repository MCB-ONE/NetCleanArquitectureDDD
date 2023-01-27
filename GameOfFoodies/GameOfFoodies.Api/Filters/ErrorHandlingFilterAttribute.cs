using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GameOfFoodies.Api.Filters;

// ENFOQUE MANEJO DE ERRORES 2 (Vía exception filter attribute.)
// Filtro que se va a aplicar a todos los controladores.
//  -> Cuando se lance una excepcion no controlada en nuestros controladores se invocara el método OnException el cual sobreescribimos para acceder todas aquellas excepciones no controladas y devolver una respuesta personalizada.
// PROBLEMA: No devuelve una excepción de respuesta HTTP
public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {

        // Capturar la excepción producida
        var exception = context.Exception;

        // Devolvemos los detalles del error usando el standard Problem Details Specification
        var problemDetails = new ProblemDetails {
            Type= "https://www.rfc-editor.org/rfc/rfc7231#section-6.6.1",
            Title= "Ha ocurrido un error al procesar su petición.",
            Status = (int)HttpStatusCode.InternalServerError,
        };
        
        

        context.Result = new ObjectResult(problemDetails)
        {
            StatusCode = StatusCodes.Status500InternalServerError
        };

        context.ExceptionHandled = true;
    }
}