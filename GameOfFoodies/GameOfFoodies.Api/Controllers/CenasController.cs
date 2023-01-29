using Microsoft.AspNetCore.Mvc;

namespace GameOfFoodies.Api.Controllers;

[Route("[controller]")]
public class CenasController: ApiController
{
    [HttpGet]
    public IActionResult Dinners()
    {
        return Ok(Array.Empty<string>());
    }
}