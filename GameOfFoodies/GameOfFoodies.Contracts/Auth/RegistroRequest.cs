namespace GameOfFoodies.Contracts.Authentication;

public record RegistroRequest(
    string FirstName,
    string Lastname,
    string Email,
    string Password
);