using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GameOfFoodies.Aplication.Common.Interfaces.Auth;
using GameOfFoodies.Aplication.Common.Interfaces.Services;
using GameOfFoodies.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace GameOfFoodies.Infrastructure.Auth;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSettings _jwtSettings;
    private readonly IDateTimeProvider _dateTimeProvider;

    public JwtTokenGenerator(IOptions<JwtSettings> jwtOptions, IDateTimeProvider dateTimeProvider)
    {
        _jwtSettings = jwtOptions.Value;
        _dateTimeProvider = dateTimeProvider;
    }

    public string GenerateToken(Usuario usuario)
    {
        // Defiimos la firma digital cifrada
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256
        );


        // Definimos los claims => información a enviar en el token
        var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, usuario.Nombre),
                new Claim(JwtRegisteredClaimNames.FamilyName, usuario.Apellido),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

        // Descripcion del token => defnir sus caracteristicas
        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
            claims: claims,
            signingCredentials: signingCredentials
        ); 
        
        // Generar y devolver el token => Método WriteToken(token) para devolver el token serializado a valor alfanumérico
        return  new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}