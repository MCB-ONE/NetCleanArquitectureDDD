using System.Net;
using System.Text.Json;

namespace GameOfFoodies.Api.Middleware;

//ENFOQUE MANEJO DE ERRORES 1 (Vía middleware): Middleware del controlador de errores globales
// Se usa para capturar todos los errores y eliminar la necesidad de un código de manejo de errores duplicado en toda la API
public class ErrorHandlingMiddleware {

    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try{
            await _next(context);
        }catch(Exception ex){
            await HandlerExceptionAsync(context, ex);
        }
    }

    private static Task HandlerExceptionAsync(HttpContext context, Exception ex)
    {
        var code = HttpStatusCode.InternalServerError; //505 es inesperado
        var result = JsonSerializer.Serialize(new {error = "Ha ocurrido un error al procesar su petición."});
        context.Response.ContentType = "application/json; charset=utf-8";
        context.Response.StatusCode = (int)code;

        return context.Response.WriteAsync(result);
    }
}