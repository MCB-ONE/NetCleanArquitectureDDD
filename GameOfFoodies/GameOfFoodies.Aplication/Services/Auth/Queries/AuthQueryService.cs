using ErrorOr;
using GameOfFoodies.Aplication.Common.Interfaces.Auth;
using GameOfFoodies.Aplication.Common.Interfaces.Persistence;
using GameOfFoodies.Aplication.Services.Auth.Common;
using GameOfFoodies.Domain.Common.Errors;
using GameOfFoodies.Domain.Entities;

namespace GameOfFoodies.Aplication.Services.Auth.Queries;

public class AuthQueryService : IAuthQueryService
{
    private readonly IJwtTokenGenerator _jWtTokenGenerator;
    private readonly IUsuarioRepository _usuarioRepository;

    public AuthQueryService(IJwtTokenGenerator jWtTokenGenerator, IUsuarioRepository usuarioRepository)
    {
        _jWtTokenGenerator = jWtTokenGenerator;
        _usuarioRepository = usuarioRepository;
    }

    public ErrorOr<AuthResult> Login(string email, string password)
    {
        // 1. Validar si el usaurio existe
        if(_usuarioRepository.GetUsuarioByEmail(email) is not Usuario usuario){
            return Errors.Auth.InvalidCredentials;
        }
        // 2. Validar contraseña correcta
        if(usuario.Pasword != password){
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