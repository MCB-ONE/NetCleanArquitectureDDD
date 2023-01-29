using GameOfFoodies.Aplication.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace GameOfFoodies.Api.Controllers;

public class  ErrorController : ControllerBase{

    [Route("/error")]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        return Problem();
    }

}