using GameOfFoodies.Aplication.Common.Interfaces.Auth;

namespace GameOfFoodies.Aplication.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IJwtTokenGenerator _jWtTokenGenerator;

    public AuthService(IJwtTokenGenerator jWtTokenGenerator)
    {
        _jWtTokenGenerator = jWtTokenGenerator;
    }

    public AuthResult Registro(string nombre, string apellido, string email, string password)
    {

        // TODO: Comprobar si el suruaio existe

        // Crear el usuario (generando un ID unico)
        var usuarioId = Guid.NewGuid();

        // Crear el JWT Token
        var token = _jWtTokenGenerator.GenerateToken(usuarioId, nombre, apellido);

        return new AuthResult(
            usuarioId,
            nombre,
            apellido,
            email,
            token);
    }
    public AuthResult Login(string email, string password)
    {
        
        return new AuthResult(
            Guid.NewGuid(),
            "firstName",
            "lastName",
            email,
            "token");
    }

}