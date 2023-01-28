using GameOfFoodies.Domain.Entities;

namespace GameOfFoodies.Aplication.Auth.Common;

public record AuthResult(
    Usuario Usuario,
    string Token
);