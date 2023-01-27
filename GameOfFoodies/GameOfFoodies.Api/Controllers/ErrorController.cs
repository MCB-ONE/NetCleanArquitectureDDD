using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace GameOfFoodies.Api.Controllers;

public class  ErrorController : ControllerBase{

    // Controlador de redireccion de errores. Recive el error
    [Route("/error")]
    public IActionResult Error()
    {
        // Capturamos la excepción lanzada por el error y devolvemos los detalles del problema (ProblemDetailsFactory)
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        
        return Problem();
    }

}