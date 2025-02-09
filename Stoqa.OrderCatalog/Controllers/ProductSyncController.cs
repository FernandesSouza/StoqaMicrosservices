using Microsoft.AspNetCore.Mvc;
using Stoqa.OrderCatalog.ApplicationService.DTOs.ProductDtos;
using Stoqa.OrderCatalog.ApplicationService.Interfaces.Service;

namespace Stoqa.OrderCatalog.Controllers;

[Route("api/[Controller]")]
[ApiController]
public sealed class ProductSyncController(
    IProductCommandSyncService productCommandSyncService
) : ControllerBase
{
    [HttpPost("register_product")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<bool> RegisterSyncProduct([FromBody] ProductRegisterSyncRequest productRegisterRequestDto) =>
        await productCommandSyncService.RegisterAsync(productRegisterRequestDto);
}