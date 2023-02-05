using GameOfFoodies.Domain.UsuarioAggregate;

namespace GameOfFoodies.Aplication.Common.Interfaces.Auth;

public interface IJwtTokenGenerator{
    string GenerateToken(Usuario usuario);
}