using GameOfFoodies.Domain.Entities;

namespace GameOfFoodies.Aplication.Common.Interfaces.Persistence;

public interface IUsuarioRepository{
    Usuario? GetUsuarioByEmail(string email);
    void Add(Usuario usaurio); 
}