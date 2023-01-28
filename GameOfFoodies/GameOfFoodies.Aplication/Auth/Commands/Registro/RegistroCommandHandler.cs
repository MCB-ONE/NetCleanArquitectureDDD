using ErrorOr;
using GameOfFoodies.Aplication.Auth.Common;
using GameOfFoodies.Aplication.Common.Interfaces.Auth;
using GameOfFoodies.Aplication.Common.Interfaces.Persistence;
using GameOfFoodies.Domain.Common.Errors;
using GameOfFoodies.Domain.Entities;
using MediatR;

namespace GameOfFoodies.Aplication.Auth.Commands.Registro;

// Creacion de manejador de commando del patron CQRS usando mediador MediatR 
// => Inyectar las dependencias especificas para el manejador de commando 
// => Realizar la lógica necesaria (en este caso para registrar/ guardar un nuevo usuario)
public class RegistroCommandHandler : IRequestHandler<RegistroCommand, ErrorOr<AuthResult>>
{
    private readonly IJwtTokenGenerator _jWtTokenGenerator;
    private readonly IUsuarioRepository _usuarioRepository;

    public RegistroCommandHandler(IJwtTokenGenerator jWtTokenGenerator, IUsuarioRepository usuarioRepository)
    {
        _jWtTokenGenerator = jWtTokenGenerator;
        _usuarioRepository = usuarioRepository;
    }
    public async Task<ErrorOr<AuthResult>> Handle(RegistroCommand command, CancellationToken cancellationToken)
    {

        // 1. Validar que el usuario no existe
        if (_usuarioRepository.GetUsuarioByEmail(command.Email) is not null)
        {
            return Errors.Usuario.DuplicateEmail;
        }

        // 2. Crear el usuario (generando un ID único) y persisitrlo en la BBDD
        // 2.1 El id se genera automaticamente al crear un nuevo objeto usuario
        var usuario = new Usuario
        {
            Nombre = command.Nombre,
            Apellido = command.Apellido,
            Email = command.Email,
            Pasword = command.Password
        };

        _usuarioRepository.Add(usuario);

        // 3. Crear el JWT Token
        var token = _jWtTokenGenerator.GenerateToken(usuario);

        // 4. Devolver respuesta de autorización
        return new AuthResult(
            usuario,
            token);
    }
}