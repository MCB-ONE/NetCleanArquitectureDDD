using GameOfFoodies.Aplication.Menus.Commands.CreateMenu;
using GameOfFoodies.Contracts.Menus;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace GameOfFoodies.Api.Controllers;

[Route("huespedes/{huespedId}/menus")]
public class MenusController: ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public MenusController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<IActionResult> CreateMenu(CreateMenuRequest request, string huespedId)
    {
        var command = _mapper.Map<CreateMenuCommand>((request, huespedId));
        
        var createMenuResult = await _mediator.Send(command);


        return createMenuResult.Match(
            menu => Ok(_mapper.Map<MenuResponse>(menu)),
            errors => Problem(errors));
    }

}