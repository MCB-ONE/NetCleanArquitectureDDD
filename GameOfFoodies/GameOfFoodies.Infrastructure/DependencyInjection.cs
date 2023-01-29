using System.Text;
using GameOfFoodies.Aplication.Common.Interfaces.Auth;
using GameOfFoodies.Aplication.Common.Interfaces.Persistence;
using GameOfFoodies.Aplication.Common.Interfaces.Services;
using GameOfFoodies.Infrastructure.Auth;
using GameOfFoodies.Infrastructure.Persistence;
using GameOfFoodies.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace GameOfFoodies.Infrastructure;

public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddAuth(config);
        
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        return services;
    }

    public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration config)
    {
        var jwtSettings = new JwtSettings();
        config.Bind(JwtSettings.SectionName, jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        // Definimos JwtBearer como nuestro esquema de autenticación por defecto, validamos el JWT Token que llegan en las cabeceras de las peticiones Http y completamos los claims con la info que llega en él
        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters{
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings.Secret)
            )
            }
        );

        return services;
    }

}