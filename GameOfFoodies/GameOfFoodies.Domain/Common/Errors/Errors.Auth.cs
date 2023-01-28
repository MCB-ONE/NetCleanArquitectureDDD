using ErrorOr;

namespace GameOfFoodies.Domain.Common.Errors;

public static partial class Errors
{
    public static class Auth 
    {
        public static Error InvalidCredentials => Error.Validation(
            code: "Auth.InvalidCred",
            description: "Credenciales incorrectas."
        );
    }
}