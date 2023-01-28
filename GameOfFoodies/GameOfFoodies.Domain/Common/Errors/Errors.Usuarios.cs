using ErrorOr;

namespace GameOfFoodies.Domain.Common.Errors;

public static partial class Errors
{
    public static class Usuario 
    {
        public static Error DuplicateEmail => Error.Conflict(
            code: "Usuario.DuplicateEmail",
            description: "Este email ya existe."
        );
    }
}