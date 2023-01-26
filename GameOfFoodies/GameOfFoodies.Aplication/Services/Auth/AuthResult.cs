using GameOfFoodies.Domain.Entities;

namespace GameOfFoodies.Aplication.Services.Auth;

public record AuthResult(
    Usuario Usuario,
    string Token
);