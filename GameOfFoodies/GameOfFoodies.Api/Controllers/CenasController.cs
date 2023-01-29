using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameOfFoodies.Api.Controllers;

[Route("[controller]")]
[Authorize]
public class CenasController: ApiController
{
    [HttpGet]
    public IActionResult Cenas()
    {
        return Ok(Array.Empty<string>());
    }
}