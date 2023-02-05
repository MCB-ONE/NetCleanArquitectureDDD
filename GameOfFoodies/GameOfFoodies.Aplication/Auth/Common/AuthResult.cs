using GameOfFoodies.Domain.UsuarioAggregate;

namespace GameOfFoodies.Aplication.Auth.Common;

public record AuthResult(
    Usuario Usuario,
    string Token
);