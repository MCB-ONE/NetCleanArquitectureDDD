
 ![Game of Foodies showcase](showcaseGameOfFoodies.jpg)
- [Descripción general](#descripción-general)
- [Arquitectura del servicio](#arquitectura-del-servicio)

# Descripción general
API REST desde cero usando .NET 6 en C# y con la tecnología WebAPI. Para el desarrollo del proyecto se han seguido los principios de la Arquitectura Limpia (Clean Arquitecture) y los principios del Diseño Impulsado por el Dominio (DDD). 
El sistema backend tiene un sistema de autenticación basado en JWT y la creación, lectura, actualización y eliminación de cenas.

# Arquitectura del servicio
El servicio esta distribuido en 4 capas diferentes, cada una con sus propias responsabilidades y permiten mantener nuestro código separado y ordenado: 
* Dominio: núcleo del sistema donde se definen los agregados, los objetos  de valor y demás entidades o modelos que pertenecen a la lógica de negocio.
* Aplicación: en ella aplicamos los patrones repositorio, CQRS, Unit Of work y demás lógica que forma parte de los casos de uso y depende directamente de la capa de dominio.
* Infraestructura: encontramos las implementaciones concretas de los servicios/interfaces definidas en la capa de aplicación.
* API: es la capa de presentación y encargada de conectar nuestro sistema con el mundo exterior y en este caso donde aplicamos la arquitectura API Rest