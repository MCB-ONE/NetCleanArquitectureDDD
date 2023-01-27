
using GameOfFoodies.Api.Filters;
using GameOfFoodies.Aplication;
using GameOfFoodies.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{

    var config = builder.Configuration;

    builder.Services
    .AddApplication()
    .AddInfrastructure(config);

    //Aplicar filtro de excepciones en todos los controladores de la app
    builder.Services.AddControllers( options => options.Filters.Add<ErrorHandlingFilterAttribute>());
}


var app = builder.Build();
{
    //app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
