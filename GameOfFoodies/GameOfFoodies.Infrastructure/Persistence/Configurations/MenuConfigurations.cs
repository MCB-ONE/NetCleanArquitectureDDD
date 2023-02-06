using GameOfFoodies.Domain.HuespedAggregate.ValueObjects;
using GameOfFoodies.Domain.MenuAggregate;
using GameOfFoodies.Domain.MenuAggregate.Entities;
using GameOfFoodies.Domain.MenuAggregate.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameOfFoodies.Infrastructure.Persistence.Configurations;

public class MenuConfiguration : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        ConfigureMenusTable(builder);
        ConfigureSeccionesMenuTable(builder);
        ConfigureMenuCenaIdsTable(builder);
        ConfigureMenuResenaIdsTable(builder);
    }

    private void ConfigureMenuResenaIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(menu => menu.ResenaMenuIds, resenaIdsBuilder =>
        {
            resenaIdsBuilder.ToTable("MenuResenaIds");
            resenaIdsBuilder.WithOwner().HasForeignKey("MenuId");
            resenaIdsBuilder.HasKey("Id");
            resenaIdsBuilder.Property(resena => resena.Value)
             .HasColumnName("ResenaId")
             .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(Menu.ResenaMenuIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuCenaIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(menu => menu.CenaIds, cenaIdsBuilder =>
        {
            cenaIdsBuilder.ToTable("MenuCenaIds");
            cenaIdsBuilder.WithOwner().HasForeignKey("MenuId");
            cenaIdsBuilder.HasKey("Id");
            cenaIdsBuilder.Property(cena => cena.Value)
             .HasColumnName("CenaId")
             .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(Menu.CenaIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureSeccionesMenuTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.Secciones, seccionBuilder =>
        {

            seccionBuilder.ToTable("SeccionesMenu");

            seccionBuilder
                .WithOwner()
                .HasForeignKey("MenuId");

            seccionBuilder
                .HasKey("Id", "MenuId");

            seccionBuilder
                .Property(seccion => seccion.Id)
                .HasColumnName("SeccionMenuId")
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => SeccionMenuId.Create(value));

            seccionBuilder
                .Property(seccion => seccion.Nombre)
                .HasMaxLength(100);

            seccionBuilder
                .Property(seccion => seccion.Descripcion)
                .HasMaxLength(100);

            seccionBuilder.OwnsMany(
                seccion => seccion.Platos,
                platosBuilder => ConfigurePlatosMenuTable(platosBuilder));

            seccionBuilder.Navigation(seccion => seccion.Platos).Metadata.SetField("_platos");
            seccionBuilder.Navigation(seccion => seccion.Platos).UsePropertyAccessMode(PropertyAccessMode.Field);

        });

        // Dado que tenemos listas privadas (no accesibles) como campos del agregado menú debemos configurar entityFramework para que rellene el campo de la tabla pertinente con el campo de respaldo y no con dicha lista privada   
        builder.Metadata.FindNavigation(nameof(Menu.Secciones))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

    }

    private static void ConfigurePlatosMenuTable(OwnedNavigationBuilder<SeccionMenu, PlatoMenu> platosBuilder)
    {
        platosBuilder.ToTable("PlatosMenu");
        
        platosBuilder
            .WithOwner()
            .HasForeignKey("SeccionMenuId", "MenuId");

        platosBuilder.HasKey(nameof(PlatoMenu.Id), "SeccionMenuId", "MenuId");

        platosBuilder
            .Property(plato => plato.Id)
            .HasColumnName("PlatoMenuId")
            .ValueGeneratedOnAdd()
            .HasConversion(
                id => id.Value,
                value => PlatoMenuId.Create(value));

        platosBuilder
            .Property(plato => plato.Nombre)
            .HasMaxLength(100);

        platosBuilder
            .Property(plato => plato.Descripcion)
            .HasMaxLength(100);
    }

    private void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
    {
        builder.ToTable("Menus");

        builder.HasKey(menu => menu.Id);

        builder
            .Property(menu => menu.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => MenuId.Create(value));

        builder
            .Property(menu => menu.Nombre)
            .HasMaxLength(100);

        builder
            .Property(menu => menu.Descripcion)
            .HasMaxLength(100);

        builder
            .OwnsOne(menu => menu.PuntuacionMedia);

        builder
            .Property(menu => menu.HuespedId)
            .HasConversion(
                id => id.Value,
                value => HuespedId.Create(value));

    }
}