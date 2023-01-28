using ErrorOr;

namespace GameOfFoodies.Aplication.Services.Auth;

public interface IAuthService{
    // Enfoque OneOf: Uso de esta libreria para el control de flujo
    // Básicamente permite controlar que los métodos devuelvan un tipo u otro de dato esperado.
    ErrorOr<AuthResult> Registro(string nombre, string apellido, string email, string password);
    ErrorOr<AuthResult> Login(string email, string password);
}