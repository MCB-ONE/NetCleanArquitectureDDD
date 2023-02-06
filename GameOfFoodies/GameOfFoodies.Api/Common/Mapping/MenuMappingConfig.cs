using GameOfFoodies.Aplication.Menus.Commands.CreateMenu;
using GameOfFoodies.Contracts.Menus;
using GameOfFoodies.Domain.MenuAggregate;

using Mapster;

using SeccionMenu = GameOfFoodies.Domain.MenuAggregate.Entities.SeccionMenu;

using PlatoMenu = GameOfFoodies.Domain.MenuAggregate.Entities.PlatoMenu;

namespace GameOfFoodies.Api.Common.Mapping;

// Agrupamos todas las configuraciones de mapeo de los diferentes objetos involucrado en el flujo de autenticacíon
public class MenuMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateMenuRequest Request, string HuespedId), CreateMenuCommand>()
            .Map(dest => dest.HuespedId, src => src.HuespedId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<Menu, MenuResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.PuntuacionMedia, 
                    src => src.PuntuacionMedia.NumPuntuaciones > 0 
                    ? src.PuntuacionMedia.Valor : 0)
            .Map(dest => dest.HuespedId, src => src.HuespedId.Value)
            .Map(dest => dest.CenaIds, src => src.CenaIds.Select(cenaId => cenaId.Value))
            .Map(dest => dest.ResenaMenuIds, src => src.ResenaMenuIds.Select(resenaId => resenaId.Value));

        config.NewConfig<SeccionMenu, SeccionMenuResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);

        config.NewConfig<PlatoMenu, PlatoMenuResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
            
            
    }
}