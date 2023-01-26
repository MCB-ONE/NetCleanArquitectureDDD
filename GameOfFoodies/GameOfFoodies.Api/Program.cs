
using GameOfFoodies.Api.Middleware;
using GameOfFoodies.Aplication;
using GameOfFoodies.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{

    var config = builder.Configuration;

    builder.Services
    .AddApplication()
    .AddInfrastructure(config);

    builder.Services.AddControllers();
}


var app = builder.Build();
{
    app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
