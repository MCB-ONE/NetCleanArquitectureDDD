using GameOfFoodies.Aplication.Services.Auth.Commands;
using GameOfFoodies.Aplication.Services.Auth.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace GameOfFoodies.Aplication;

public static class DependencyInjection
{

    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddScoped<IAuthCommandService, AuthCommandService>();
        service.AddScoped<IAuthQueryService, AuthQueryService>();
        
        return service;
    }

}