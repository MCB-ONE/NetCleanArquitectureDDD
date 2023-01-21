
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
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
