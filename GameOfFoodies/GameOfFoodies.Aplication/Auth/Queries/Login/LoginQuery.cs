using ErrorOr;
using GameOfFoodies.Aplication.Auth.Common;
using MediatR;

namespace GameOfFoodies.Aplication.Auth.Queries.Login;

// Definición de una consulta (query) del patron CQRS usando mediador MediatR
// Definición de los datos que necesitamos
// Definición de lo que deve devolver el commando
public record LoginQuery(
    string Email,
    string Password): IRequest<ErrorOr<AuthResult>>;