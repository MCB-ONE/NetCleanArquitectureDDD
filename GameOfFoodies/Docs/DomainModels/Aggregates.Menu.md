# Domain Models

## Menu

```csharp
class Menu
{
    Menu Create();
    void AddCena(Cena cena);
    void DeleteCena(int cenaId);
    void AddSeccion(Seccion seccion);
    void UpdateSeccion(Seccion seccion);
    void DeleteSeccion(int seccionId);
    void AddResena(Resena resena);
    void DeleteResena(int resenaId);
}
```
```json
{
    "id": {"value": "00000000-0000-0000-0000-000000000000"},
    "nombre": "Menú vegano",
    "descripcion": "Todo vegano! Únete a nostros para disfrutar de una cena saludable..",
    "secciones": [
        {
            "id": {"value": "00000000-0000-0000-0000-000000000000"},
            "nombre": "Aperitivo",
            "descripcion": "Entrantes",
            "platos": [
                {
                    "id": {"value": "00000000-0000-0000-0000-000000000000"},
                    "nombre": "Tempura de hortalizas",
                    "descripcion": "Fritura de hortalizas variadas al estilo japonés",
                    "precio": 5.30
                },
            ]
        },
    ],
    "huespedId": {"value": "00000000-0000-0000-0000-000000000000"},
    "cenaIds": [
        {"value": "00000000-0000-0000-0000-000000000000"},
    ],
    "resenaIds": [
        {"value": "00000000-0000-0000-0000-000000000000"},
    ],
    "creacionFechaHora": "2022-04-08T08:00:00",
    "modificacionFechaHora": "2022-04-08T11:00:00"
}
```