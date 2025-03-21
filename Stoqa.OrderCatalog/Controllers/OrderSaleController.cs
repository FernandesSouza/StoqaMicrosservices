using Microsoft.AspNetCore.Mvc;
using Stoqa.OrderCatalog.ApplicationService.DTOs.OrderSaleDtos;
using Stoqa.OrderCatalog.ApplicationService.Interfaces.Service;

namespace Stoqa.OrderCatalog.Controllers;

[Route("api/[Controller]")]
[ApiController]
public sealed class OrderSaleController(
    IOrderSaleCommandService orderSaleCommandService,
    IOrderSaleQueryService orderSaleQueryService
) : ControllerBase
{
    [HttpPost("register_order")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<bool> RegisterOrder([FromBody] OrderSaleRegisterRequest productRegisterRequestDto) =>
        await orderSaleCommandService.RegisterAsync(productRegisterRequestDto);

    [HttpPatch("update_conference_status")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<bool> UpdateConferenceStatus(long orderId) =>
        await orderSaleCommandService.UpdateConferenceStatusAsync(orderId);

    [HttpGet("get_by_order_id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<OrderConferenceResponse> GetByOrderId([FromQuery] long orderId) =>
        await orderSaleQueryService.GetByIdAsync(orderId);
}