using GameOfFoodies.Aplication.Services.Auth;
using GameOfFoodies.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace GameOfFoodies.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("registro")]
    public IActionResult Registro(RegistroRequest request)
    {
        var authResult = _authService.Registro(
            request.FirstName,
            request.Lastname,
            request.Email,
            request.Password);

        var response = new AuthResponse(
            authResult.Id,
            authResult.FirstName,
            authResult.Lastname,
            authResult.Email,
            authResult.Token
        );

        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authService.Login(
            request.Email,
            request.Password);

        var response = new AuthResponse(
            authResult.Id,
            authResult.FirstName,
            authResult.Lastname,
            authResult.Email,
            authResult.Token
        );

        return Ok(response);
    }

}