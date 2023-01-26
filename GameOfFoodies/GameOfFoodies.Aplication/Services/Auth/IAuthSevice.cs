namespace GameOfFoodies.Aplication.Services.Auth;

public interface IAuthService{
    AuthResult Registro(string nombre, string apellido, string email, string password);
    AuthResult Login(string email, string password);
}