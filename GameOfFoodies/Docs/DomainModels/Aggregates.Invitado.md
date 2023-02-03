# Domain Models

## Invitado

```csharp
class Invitado
{
    //TODO: Add methods
}
```

```json
{
    "id": { "value": "00000000-0000-0000-0000-000000000000" },
    "nombre": "John",
    "apellido": "Doe",
    "imagenPerfil": "https://www.gravatar.com/avatar/00000000000000000000000000000000?d=mp",
    "puntuacionMedia": 4.5,
    "usuarioId": { "value": "00000000-0000-0000-0000-000000000000" },
    "cenasProximasIds": [
        { "value": "00000000-0000-0000-0000-000000000000" }
    ],
    "cenasPasadasIds": [
        { "value": "00000000-0000-0000-0000-000000000000" }
    ],
    "cenasPendientesIds": [
        { "value": "00000000-0000-0000-0000-000000000000" }
    ],
    "factruraIds": [
        { "value": "00000000-0000-0000-0000-000000000000" }
    ],
    "menuResenaIds": [
        { "value": "00000000-0000-0000-0000-000000000000" }
    ],
    "valoraciones": [
        {
            "id": { "value": "00000000-0000-0000-0000-000000000000" },
            "huespedId": { "value": "00000000-0000-0000-0000-000000000000" },
            "cenaId": { "value": "00000000-0000-0000-0000-000000000000" },
            "valoracion": 4,
            "creadoFechaHora": "2020-01-01T00:00:00.0000000Z",
            "modificadoFechaHora": "2020-01-01T00:00:00.0000000Z"
        }
    ],
    "creadoFechaHora": "2020-01-01T00:00:00.0000000Z",
    "modificadoFechaHora": "2020-01-01T00:00:00.0000000Z"
}
```