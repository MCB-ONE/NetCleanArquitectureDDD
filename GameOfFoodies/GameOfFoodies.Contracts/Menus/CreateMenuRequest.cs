namespace GameOfFoodies.Contracts.Menus;

public record CreateMenuRequest(
    string Nombre,
    string Descripcion,
    List<SeccionMenu> Secciones
);

public record SeccionMenu(
    string Nombre,
    string Descripcion,
    List<PlatoMenu> Platos
);

public record PlatoMenu(
    string Nombre,
    string Descripcion
);
