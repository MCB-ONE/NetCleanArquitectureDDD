namespace GameOfFoodies.Contracts.Authentication;

public record AuthResponse(
    Guid Id,
    string FirstName,
    string Lastname,
    string Email,
    string Token
);