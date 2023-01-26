namespace GameOfFoodies.Contracts.Authentication;

public record RegistroRequest(
    string Nombre,
    string Apellido,
    string Email,
    string Password
);