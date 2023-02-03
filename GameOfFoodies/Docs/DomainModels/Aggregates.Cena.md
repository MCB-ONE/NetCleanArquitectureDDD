# Domain Models

## Cena

```csharp
class Cena
{
    //TODO: Add methods
}
```

```json
{
    "id": { "value": "00000000-0000-0000-0000-000000000000" },
    "nombre": "Yummy Dinner",
    "descripcion": "A dinner with yummy food",
    "inicioDateTime": "2020-01-01T00:00:00.0000000Z",
    "finDateTime": "2020-01-01T00:00:00.0000000Z",
    "iniciadoDateTime": null,
    "finalizadoDateTime": null,
    "estatus": "Proximamente", // Proximamente, EnProceso, Finalizada, Cancelada
    "esPublica": true,
    "maxInivtados": 10,
    "precio": {
        "total": 10.99,
        "divisa": "EUR"
    },
    "huestpedId": { "value": "00000000-0000-0000-0000-000000000000" },
    "menuId": { "value": "00000000-0000-0000-0000-000000000000" },
    "urlImagen": "https://image.com",
    "localizacion": {
        "nombre": "Dan's Pizza Place",
        "direccion": "Berlin, Germany",
        "latitud": 52.520008,
        "longitud": 13.404954
    },
    "reservas": [
        {
            "id": { "value": "00000000-0000-0000-0000-000000000000" },
            "invitadosCuenta": 2,
            "reservasEtatus": "Reservedo", // InvitadoPendienteConfirmacion, Reservado, Cancelado
            "invitadoId": { "value": "00000000-0000-0000-0000-000000000000" },
            "facturaId": { "value": "00000000-0000-0000-0000-000000000000 }",
            "llegadaFechaHora": null,
            "creadoFechaHora":  "2020-01-01T00:00:00.0000000Z",
            "modificadoFechaHora":  "2020-01-01T00:00:00.0000000Z"
        }
    ],
    "creadoFechaHora": "2022-04-08T08:00:00",
    "modificadoFechaHora": "2022-04-08T11:00:00"
}

```