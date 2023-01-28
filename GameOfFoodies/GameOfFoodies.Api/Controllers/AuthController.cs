using ErrorOr;
using GameOfFoodies.Aplication.Services.Auth;
using GameOfFoodies.Aplication.Services.Auth.Commands;
using GameOfFoodies.Aplication.Services.Auth.Common;
using GameOfFoodies.Aplication.Services.Auth.Queries;
using GameOfFoodies.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace GameOfFoodies.Api.Controllers;

[Route("auth")]
public class AuthController : ApiController
{
    private readonly IAuthCommandService _authCommandService;
    private readonly IAuthQueryService _authQueryService;

    public AuthController(IAuthCommandService authCommandService, IAuthQueryService authQueryService)
    {
        _authCommandService = authCommandService;
        _authQueryService = authQueryService;
    }

    [HttpPost("registro")]
    public IActionResult Registro(RegistroRequest request)
    {
        ErrorOr<AuthResult> authResult = _authCommandService.Registro(
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
        ErrorOr<AuthResult> authResult = _authQueryService.Login(
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