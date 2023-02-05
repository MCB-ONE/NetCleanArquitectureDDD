using GameOfFoodies.Aplication.Common.Interfaces.Persistence;
using GameOfFoodies.Domain.UsuarioAggregate;

namespace GameOfFoodies.Infrastructure.Persistence;

public class UsuarioRepository : IUsuarioRepository
{
    // Lista estática para que solo se cree una vez al ser invocada por el servicio. 
    // => Solo existe una copia de un miembro estático, independientemente del número de instancias de la clase que se creen.
    // => Permite simular que persisten los datos a lo largo del ciclo de vida de la api.
    
    private static readonly List<Usuario> _usuarios = new(); 
    public void Add(Usuario usaurio)
    {
        _usuarios.Add(usaurio);
    }

    public Usuario? GetUsuarioByEmail(string email)
    {
       return _usuarios.SingleOrDefault(u => u.Email == email);
    }
}