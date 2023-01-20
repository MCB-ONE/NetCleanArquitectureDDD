namespace GameOfFoodies.Aplication.Services.Auth;

public record AuthResult(
    Guid Id,
    string FirstName,
    string Lastname,
    string Email,
    string Token
);