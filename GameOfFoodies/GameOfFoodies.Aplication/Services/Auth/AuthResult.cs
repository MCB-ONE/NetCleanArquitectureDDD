namespace GameOfFoodies.Aplication.Services.Auth;

public record AuthResult(
    Guid Id,
    string Nombre,
    string Apellido,
    string Email,
    string Token
);