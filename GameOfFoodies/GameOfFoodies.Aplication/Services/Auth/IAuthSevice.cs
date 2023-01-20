namespace GameOfFoodies.Aplication.Services.Auth;

public interface IAuthService{
    AuthResult Registro(string firstName, string lastName, string email, string password);
    AuthResult Login(string email, string password);
}