using Microsoft.AspNetCore.Mvc;
using Stoqa.ProductCatalog.ApplicationService.DTOs.StockItemDtos.Request;
using Stoqa.ProductCatalog.ApplicationService.DTOs.StockItemDtos.Response;
using Stoqa.ProductCatalog.ApplicationService.Interfaces.ServicesContracts;
using Stoqa.ProductCatalog.Domain.Handlers.NotificationHandler;
using Stoqa.ProductCatalog.Domain.PaginationHandler;
using Stoqa.ProductCatalog.Domain.PaginationHandler.Params;

namespace Stoqa.ProductCatalog.Controllers;

[Route("api/[Controller]")]
[ApiController]
public sealed class StockItemController(
    IStockItemCommandService stockItemCommandService,
    IStockItemQueryService stockItemQueryService
) : ControllerBase
{
    [HttpPost("register_stockItem")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    public async Task<bool> Register([FromBody] StockItemRegisterRequest stockItemRegisterRequest) =>
        await stockItemCommandService.RegisterAsync(stockItemRegisterRequest);

    [HttpGet("find_all_with_pagination_stockItem")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    public async Task<PageList<StockItemSimpleResponse>> FindAllWithPagination(
        [FromQuery] StockItemParams stockItemParams) =>
        await stockItemQueryService.FindAllWithPaginationAsync(stockItemParams);
}