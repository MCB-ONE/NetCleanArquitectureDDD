using ErrorOr;
using GameOfFoodies.Api.Common.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameOfFoodies.Api.Controllers;

[ApiController]
public class ApiController: ControllerBase
{
    protected IActionResult Problem(List<Error> errors)
    {
        HttpContext.Items[HttpContextItemKeys.Errors] = errors;


        // TODO: Completar lógica cuando tengamos la válidación del modelo en nuestro ervicio
        var firstError = errors[0];

        var statusCode = firstError.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError,
        }; 

        return Problem(statusCode: statusCode, title: firstError.Description);
    }
}