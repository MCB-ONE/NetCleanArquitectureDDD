 namespace GameOfFoodies.Domain.UsuarioAggregate;

 public class Usuario {
    public Guid Id {get; set;} = Guid.NewGuid();
    public string Nombre {get; set;} = null!;
    public string Apellido {get; set;} = null!;
    public string Email {get; set;} = null!;
    public string Pasword {get; set;} = null!;
 }