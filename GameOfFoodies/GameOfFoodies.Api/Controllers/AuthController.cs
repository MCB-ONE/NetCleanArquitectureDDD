using FluentResults;
using GameOfFoodies.Aplication.Common.Errors;
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
        Result<AuthResult> registerResult = _authService.Registro(
                    request.Nombre,
                    request.Apellido,
                    request.Email,
                    request.Password);
        
        if(registerResult.IsSuccess)
        {
            return Ok(MapAuthResult(registerResult.Value));
        }

        var firstError = registerResult.Errors[0];

        if(firstError is DuplicateEmailError)
        {
            return Problem(statusCode: StatusCodes.Status409Conflict, title: "El email ya existe.");
        }

        return Problem();
    }

    // Refactorización: Método auxiliar para mapear la respuesta correcta del authService.Registro() que es un AuthResult a AuthResponse (Typo obligado a devolver por contrato)
    private static AuthResponse MapAuthResult(AuthResult authResult)
    {
        return new AuthResponse(
        authResult.Usuario.Id,
        authResult.Usuario.Nombre,
        authResult.Usuario.Apellido,
        authResult.Usuario.Email,
        authResult.Token);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authService.Login(
            request.Email,
            request.Password);

        var response = new AuthResponse(
            authResult.Usuario.Id,
            authResult.Usuario.Nombre,
            authResult.Usuario.Apellido,
            authResult.Usuario.Email,
            authResult.Token
        );

        return Ok(response);
    }

}