namespace GameOfFoodies.Aplication.Common.Interfaces.Auth;

public interface IJwtTokenGenerator{
    string GenerateToken(Guid id ,string nombre, string apellido);
}