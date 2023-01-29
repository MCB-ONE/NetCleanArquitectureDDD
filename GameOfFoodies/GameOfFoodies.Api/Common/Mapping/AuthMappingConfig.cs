using GameOfFoodies.Aplication.Auth.Commands.Registro;
using GameOfFoodies.Aplication.Auth.Common;
using GameOfFoodies.Aplication.Auth.Queries.Login;
using GameOfFoodies.Contracts.Authentication;
using Mapster;

namespace GameOfFoodies.Api.Common.Mapping;

// Agrupamos todas las configuraciones de mapeo de los diferentes objetos involucrado en el flujo de autenticacíon
public class AuthMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegistroRequest, RegistroCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();
        config.NewConfig<AuthResult, AuthResponse>()
        .Map(dest => dest, src => src.Usuario);
    }
}