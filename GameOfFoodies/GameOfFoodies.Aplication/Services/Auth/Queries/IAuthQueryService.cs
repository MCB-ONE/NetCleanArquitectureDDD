using ErrorOr;
using GameOfFoodies.Aplication.Services.Auth.Common;

namespace GameOfFoodies.Aplication.Services.Auth.Queries;

public interface IAuthQueryService{
     // Patrón CQRS: Subsistema de commandos para el servicio de autenticación de usurios
    ErrorOr<AuthResult> Login(string email, string password);
}