using ErrorOr;
using GameOfFoodies.Aplication.Auth.Commands.Registro;
using GameOfFoodies.Aplication.Auth.Common;
using GameOfFoodies.Aplication.Auth.Queries.Login;
using GameOfFoodies.Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameOfFoodies.Api.Controllers;

[Route("auth")]
public class AuthController : ApiController
{
    // Implementamos patron CQRS con MediatR => El mediador llama al manejador CQRS según el command o la query que se le envíe
    private readonly ISender _mediator;

    public AuthController(ISender mediator)
    {
        this._mediator = mediator;
    }

    [HttpPost("registro")]
    public async Task<IActionResult> Registro(RegistroRequest request)
    {
        var command = new RegistroCommand(
            request.Nombre,
            request.Apellido,
            request.Email,
            request.Password
        );

        ErrorOr<AuthResult> authResult = await _mediator.Send(command);

        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = new LoginQuery(
            request.Email,
            request.Password
        );
        
        ErrorOr<AuthResult> authResult = await _mediator.Send(query);


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