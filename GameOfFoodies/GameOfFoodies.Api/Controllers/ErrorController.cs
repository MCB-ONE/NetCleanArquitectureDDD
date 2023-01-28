using GameOfFoodies.Aplication.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace GameOfFoodies.Api.Controllers;

public class  ErrorController : ControllerBase{

    // Controlador de redirección de errores. Recibe el error
    [Route("/error")]
    public IActionResult Error()
    {
        // Capturamos la excepción lanzada por el error y devolvemos los detalles del problema (ProblemDetailsFactory)
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        
        var (statusCode, message) = exception switch
        {
            DuplicateEmailException => (StatusCodes.Status409Conflict, "El email ya existe."), _ => (StatusCodes.Status500InternalServerError, "An unexpected error ocurred.")
        };

        return Problem(statusCode: statusCode, title: message);
    }

}