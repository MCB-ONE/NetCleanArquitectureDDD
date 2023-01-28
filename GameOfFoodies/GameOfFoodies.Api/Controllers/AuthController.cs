using ErrorOr;
using GameOfFoodies.Aplication.Services.Auth;
using GameOfFoodies.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace GameOfFoodies.Api.Controllers;

[Route("auth")]
public class AuthController : ApiController
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("registro")]
    public IActionResult Registro(RegistroRequest request)
    {
        ErrorOr<AuthResult> authResult = _authService.Registro(
            request.Nombre,
            request.Apellido,
            request.Email,
            request.Password);

        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        ErrorOr<AuthResult> authResult = _authService.Login(
            request.Email,
            request.Password);


        if(authResult.IsError && authResult.FirstError == Domain.Common.Errors.Errors.Auth.InvalidCredentials)
        {
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
        }


        return authResult.Match(
            authResult =>  Ok(MapAuthResult(authResult)),
            errors => Problem(errors)
        );
    }

    
    private static AuthResponse MapAuthResult(AuthResult authResult)
    {
        return new AuthResponse(
                authResult.Usuario.Id,
                authResult.Usuario.Nombre,
                authResult.Usuario.Apellido,
                authResult.Usuario.Email,
                authResult.Token);
    }

}