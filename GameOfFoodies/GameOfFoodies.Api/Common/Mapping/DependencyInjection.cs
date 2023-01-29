using System.Reflection;
using Mapster;
using MapsterMapper;

namespace GameOfFoodies.Api.Common.Mapping;

public static class DependencyInjection
{

 // Configuramos mapster para que sea un servicio y no instancias estáticas. 
    public static IServiceCollection AddMappings(this IServiceCollection services)
    {
        // Escaneamos el ensamblado y agregamos las confifguraciones de mapeo que encuentremos al archivo TypeAdapterConfig
        var config = TypeAdapterConfig.GlobalSettings;

        config.Scan(Assembly.GetExecutingAssembly());

        // Agregamos los servicio
        services.AddSingleton(config); 
        services.AddScoped<IMapper, ServiceMapper>();
        
        return services;
    }

}