using GameOfFoodies.Aplication.Services.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace GameOfFoodies.Aplication;

public static class DependencyInjection
{

    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddScoped<IAuthService, AuthService>();

        return service;
    }

}