using ErrorOr;
using GameOfFoodies.Aplication.Auth.Common;
using GameOfFoodies.Aplication.Auth.Queries.Login;
using GameOfFoodies.Aplication.Common.Interfaces.Auth;
using GameOfFoodies.Aplication.Common.Interfaces.Persistence;
using GameOfFoodies.Domain.Common.Errors;
using GameOfFoodies.Domain.Entities;
using MediatR;

namespace GameOfFoodies.Aplication.Auth.Queries.Registro;

// Creacion de manejador de una query del patron CQRS usando mediador MediatR 
// => Inyectar las dependencias especificas para el manejador de la query 
// => Realizar la lógica necesaria (en este caso para dar acceso al sitema al usuario devolviendo un JWT)
public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthResult>>
{
    private readonly IJwtTokenGenerator _jWtTokenGenerator;
    private readonly IUsuarioRepository _usuarioRepository;

    public LoginQueryHandler(IJwtTokenGenerator jWtTokenGenerator, IUsuarioRepository usuarioRepository)
    {
        _jWtTokenGenerator = jWtTokenGenerator;
        _usuarioRepository = usuarioRepository;
    }

    public async Task<ErrorOr<AuthResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        // Corrección método asincrono
        await Task.CompletedTask;

        // 1. Validar si el usaurio existe
        if (_usuarioRepository.GetUsuarioByEmail(query.Email) is not Usuario usuario)
        {
            return Errors.Auth.InvalidCredentials;
        }
        // 2. Validar contraseña correcta
        if (usuario.Pasword != query.Password)
        {
            return Errors.Auth.InvalidCredentials;
        }
        // 3. Crear el JWT Token
        var token = _jWtTokenGenerator.GenerateToken(usuario);

        // 4. Devolver respuesta de autorización
        return new AuthResult(
            usuario,
            token);
    }
}