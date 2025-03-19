using Microsoft.AspNetCore.Mvc;
using Stoqa.ProductCatalog.ApplicationService.DTOs.ItemDtos;
using Stoqa.ProductCatalog.ApplicationService.Interfaces.ServicesContracts;
using Stoqa.ProductCatalog.Domain.Handlers.NotificationHandler;

namespace Stoqa.ProductCatalog.Controllers;

[Route("api/[Controller]")]
[ApiController]
public sealed class ItemController(
    IItemCommandService itemCommandService) : ControllerBase
{
    [HttpPost("register_item")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    public async Task<bool> Register([FromBody] ItemRegisterRequest itemRegisterRequest) =>
        await itemCommandService.RegisterAsync(itemRegisterRequest);
}