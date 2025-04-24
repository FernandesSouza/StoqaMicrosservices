using Microsoft.AspNetCore.Mvc;
using Stoqa.ProductCatalog.ApplicationService.DTOs.ItemDtos.Request;
using Stoqa.ProductCatalog.ApplicationService.DTOs.ItemDtos.Response;
using Stoqa.ProductCatalog.ApplicationService.Interfaces.ServicesContracts;
using Stoqa.ProductCatalog.Domain.Handlers.NotificationHandler;

namespace Stoqa.ProductCatalog.Controllers;

[Route("api/[Controller]")]
[ApiController]
public sealed class ItemController(
    IItemCommandService itemCommandService,
    IItemQueryService itemQueryService) : ControllerBase
{
    [HttpPost("register_item")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    public async Task<bool> Register([FromBody] ItemRegisterRequest itemRegisterRequest) =>
        await itemCommandService.RegisterAsync(itemRegisterRequest);

    [HttpPut("validate_conference_item")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    public async Task<bool> Conference([FromBody] ItemValidateRequest itemValidateRequest) =>
        await itemCommandService.ConcurrenceItemValidateAsync(itemValidateRequest);

    [HttpGet("get_all_items")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    public async Task<List<ItemSimpleResponse>> FindAll() =>
        await itemQueryService.FindAllAsync();
}