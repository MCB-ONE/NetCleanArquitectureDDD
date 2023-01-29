using ErrorOr;
using GameOfFoodies.Aplication.Auth.Commands.Registro;
using GameOfFoodies.Aplication.Auth.Common;
using GameOfFoodies.Aplication.Auth.Queries.Login;
using GameOfFoodies.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameOfFoodies.Api.Controllers;

[Route("auth")]
[AllowAnonymous]
public class AuthController : ApiController
{
    // Implementamos patron CQRS con MediatR => El mediador llama al manejador CQRS según el command o la query que se le envíe
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("registro")]
    public async Task<IActionResult> Registro(RegistroRequest request)
    {
        var command = _mapper.Map<RegistroCommand>(request);

        ErrorOr<AuthResult> authResult = await _mediator.Send(command);

        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthResponse>(authResult)),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);
        
        ErrorOr<AuthResult> authResult = await _mediator.Send(query);


        if(authResult.IsError && authResult.FirstError == Domain.Common.Errors.Errors.Auth.InvalidCredentials)
        {
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
        }


        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthResponse>(authResult)),
            errors => Problem(errors)
        );
    }

}