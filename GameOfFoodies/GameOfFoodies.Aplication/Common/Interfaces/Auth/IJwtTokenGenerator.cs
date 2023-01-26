using GameOfFoodies.Domain.Entities;

namespace GameOfFoodies.Aplication.Common.Interfaces.Auth;

public interface IJwtTokenGenerator{
    string GenerateToken(Usuario usuario);
}