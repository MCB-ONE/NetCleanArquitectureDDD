
using GameOfFoodies.Api.Errors;
using GameOfFoodies.Api.Filters;
using GameOfFoodies.Aplication;
using GameOfFoodies.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{

    var config = builder.Configuration;

    builder.Services
    .AddApplication()
    .AddInfrastructure(config);

    // ENFOQUE MANEJO DE ERRORES 2: Aplicar filtro de excepciones en todos los controladores de la app
    //builder.Services.AddControllers( options => options.Filters.Add<ErrorHandlingFilterAttribute>());
    builder.Services.AddControllers( );

    // Sobreescribimos 
    builder.Services.AddSingleton<ProblemDetailsFactory, GameOfFoodiesProblemDetailsFactory>();
}


var app = builder.Build();
{
    //ENFOQUE MANEJO DE ERRORES 1 (Vía middleware): Añadimos nuestro middleware personalizado. 
    //app.UseMiddleware<ErrorHandlingMiddleware>();

    //ENFOQUE MANEJO DE ERRORES 3: Añadimos UseExceptionHandler => middelware de canalización que detectará las excepciones, las registrará, restablecerá la ruta de la solicitud y volverá a ejecutar la solicitud.
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
