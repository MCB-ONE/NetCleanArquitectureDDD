using ErrorOr;
using GameOfFoodies.Aplication.Services.Auth.Common;

namespace GameOfFoodies.Aplication.Services.Auth.Commands;

public interface IAuthCommandService{
    // Patrón CQRS: Subsistema de commandos para el servicio de autenticación de usurios
    ErrorOr<AuthResult> Registro(string nombre, string apellido, string email, string password);
}