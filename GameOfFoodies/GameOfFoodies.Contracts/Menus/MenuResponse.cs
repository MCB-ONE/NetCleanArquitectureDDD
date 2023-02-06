namespace GameOfFoodies.Contracts.Menus;

public record MenuResponse(
    string Id,
    string Nombre,
    string Descripcion,
    float PuntuacionMedia,
    List<SeccionMenu> secciones,
    string HuespedId,
    List<string> CenaIds,
    List<string> ResenaMenuIds,
    DateTime CreadoFechaHora,
    DateTime ModificadoFechaHora
);

public record SeccionMenuResponse(
    string Id,
    string Nombre,
    string Descripcion,
    List<PlatoMenuResponse> platos
);

public record PlatoMenuResponse(
    string Id,
    string Nombre,
    string Descripcion
);
