
using GameOfFoodies.Api.Common.Errors;
using GameOfFoodies.Aplication;
using GameOfFoodies.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{

    var config = builder.Configuration;

    builder.Services
    .AddApplication()
    .AddInfrastructure(config);

    builder.Services.AddControllers( );

    builder.Services.AddSingleton<ProblemDetailsFactory, GameOfFoodiesProblemDetailsFactory>();
}


var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
