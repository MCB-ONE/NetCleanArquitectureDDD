 # Game Of Foodies API
- [Game Of Foodies API](#game-of-foodies-api)
  - [Menu](#menu)
    - [Create Menu](#create-menu)
      - [Create Menu Request](#create-menu-request)
      - [Create Menu Response](#create-menu-response)


## Menu

### Create Menu

#### Create Menu Request 

```js
POST huespedes/{huespedId}/menus
```

```json
{
    "nombre": "Menú vegano",
    "descripcion": "Todo vegano! Únete a nostros para disfrutar de una cena saludable..",
    "secciones": [
        {
            "nombre": "Aperitivo",
            "descripcion": "Entrantes",
            "platos": [
                {
                    "nombre": "Tempura de hortalizas",
                    "descripcion": "Fritura de hortalizas variadas al estilo japonés"
                }
            ]
        }
    ]
}
```
#### Create Menu Response
```js
200 OK
```
```json
{
    "id": {"value": "00000000-0000-0000-0000-000000000000"},
    "nombre": "Menú vegano",
    "descripcion": "Todo vegano! Únete a nostros para disfrutar de una cena saludable..",
    "puntuacionMedia": null,
    "secciones": [
        {
            "id": {"value": "00000000-0000-0000-0000-000000000000"},
            "nombre": "Aperitivo",
            "descripcion": "Entrantes",
            "platos": [
                {
                    "id": {"value": "00000000-0000-0000-0000-000000000000"},
                    "nombre": "Tempura de hortalizas",
                    "descripcion": "Fritura de hortalizas variadas al estilo japonés"
                },
            ]
        },
    ],
    "huespedId": {"value": "00000000-0000-0000-0000-000000000000"},
    "cenaIds": [
        {"value": "00000000-0000-0000-0000-000000000000"},
    ],
    "resenaMenuIds": [
        {"value": "00000000-0000-0000-0000-000000000000"},
    ],
    "creadoFechaHora": "2022-04-08T08:00:00",
    "modificadoFechaHora": "2022-04-08T11:00:00"
}
```
