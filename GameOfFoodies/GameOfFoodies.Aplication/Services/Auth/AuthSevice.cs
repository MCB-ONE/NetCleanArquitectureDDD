using GameOfFoodies.Aplication.Common.Interfaces.Auth;
using GameOfFoodies.Aplication.Common.Interfaces.Persistence;
using GameOfFoodies.Domain.Entities;

namespace GameOfFoodies.Aplication.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IJwtTokenGenerator _jWtTokenGenerator;
    private readonly IUsuarioRepository _usuarioRepository;

    public AuthService(IJwtTokenGenerator jWtTokenGenerator, IUsuarioRepository usuarioRepository)
    {
        _jWtTokenGenerator = jWtTokenGenerator;
        _usuarioRepository = usuarioRepository;
    }

    public AuthResult Registro(string nombre, string apellido, string email, string password)
    {

        // 1. Validar que el usaurio no existe
        if(_usuarioRepository.GetUsuarioByEmail(email) is not null){
            throw new Exception("Ya existe un usuario registrado con esa dirección de email.");
        }

        // 2. Crear el usuario (generando un ID unico) y persisitrlo en la BBDD
        // 2.1 El id se genera automaticamente al crear un nuevo objeto usuario
        var usuario = new Usuario{
            Nombre = nombre,
            Apellido = apellido,
            Email = email,
            Pasword = password
        };

        _usuarioRepository.Add(usuario);

        // 3. Crear el JWT Token
        var token = _jWtTokenGenerator.GenerateToken(usuario);

        // 4. Devolver respuesta de autorización
        return new AuthResult(
            usuario,
            token);
    }
    public AuthResult Login(string email, string password)
    {
        // 1. Validar si el usaurio existe
        if(_usuarioRepository.GetUsuarioByEmail(email) is not Usuario usuario){
            throw new Exception("No existe un usuario con esta dirección de email.");
        }
        // 2. Validar contraseña correcta
        if(usuario.Pasword != password){
            throw new Exception("Password incorrecto.");
        }
        // 3. Crear el JWT Token
        var token = _jWtTokenGenerator.GenerateToken(usuario);

        // 4. Devolver respuesta de autorización
        return new AuthResult(
            usuario,
            token);
    }

}