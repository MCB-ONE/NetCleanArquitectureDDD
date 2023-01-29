using System.Reflection;
using ErrorOr;
using FluentValidation;
using GameOfFoodies.Aplication.Auth.Commands.Registro;
using GameOfFoodies.Aplication.Auth.Common;
using GameOfFoodies.Aplication.Common.Behavior;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace GameOfFoodies.Aplication;

public static class DependencyInjection
{

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(DependencyInjection).Assembly); 
        
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }

}