using GameOfFoodies.Domain.Entities;

namespace GameOfFoodies.Aplication.Services.Auth.Common;

public record AuthResult(
    Usuario Usuario,
    string Token
);