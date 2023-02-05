using GameOfFoodies.Domain.UsuarioAggregate;

namespace GameOfFoodies.Aplication.Common.Interfaces.Persistence;

public interface IUsuarioRepository{
    Usuario? GetUsuarioByEmail(string email);
    void Add(Usuario usaurio); 
}