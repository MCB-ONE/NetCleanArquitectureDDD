
using GameOfFoodies.Api;
using GameOfFoodies.Aplication;
using GameOfFoodies.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{

    var config = builder.Configuration;

    // Registramos las dependencias de cada capa
    builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastructure(config);

}


var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.MapControllers();
    app.Run();
}
