using ErrorOr;
using GameOfFoodies.Aplication.Auth.Common;
using MediatR;

namespace GameOfFoodies.Aplication.Auth.Commands.Registro;

// Definición de un comando del patron CQRS usando mediador MediatR
// Definición de los datos que necesitamos
// Definición de lo que deve devolver el commando
public record RegistroCommand(
    string Nombre,
    string Apellido,
    string Email,
    string Password): IRequest<ErrorOr<AuthResult>>;