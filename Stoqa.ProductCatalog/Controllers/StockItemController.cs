using Microsoft.AspNetCore.Mvc;
using Stoqa.ProductCatalog.ApplicationService.DTOs.StockItemDtos.Request;
using Stoqa.ProductCatalog.ApplicationService.Interfaces.ServicesContracts;
using Stoqa.ProductCatalog.Domain.Handlers.NotificationHandler;

namespace Stoqa.ProductCatalog.Controllers;

[Route("api/[Controller]")]
[ApiController]
public sealed class StockItemController(
    IStockItemCommandService stockItemCommandService
) : ControllerBase
{
    [HttpPost("validate_item")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    public async Task<bool> Check([FromQuery] string serialCode, [FromQuery] long orderId) =>
        await stockItemCommandService.ConcurrenceStockItemValidateAsync(serialCode, orderId);

    [HttpPost("register_stockItem")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    public async Task<bool> Register([FromBody] StockItemRegisterRequest stockItemRegisterRequest) =>
        await stockItemCommandService.RegisterAsync(stockItemRegisterRequest);
}