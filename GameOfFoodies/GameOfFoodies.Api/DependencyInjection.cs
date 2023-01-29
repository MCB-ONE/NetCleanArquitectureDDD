using GameOfFoodies.Api.Common.Errors;
using GameOfFoodies.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace GameOfFoodies.Api;

public static class DependencyInjection
{

    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();

        services.AddSingleton<ProblemDetailsFactory, GameOfFoodiesProblemDetailsFactory>();
        services.AddMappings();

        return services;
    }

}