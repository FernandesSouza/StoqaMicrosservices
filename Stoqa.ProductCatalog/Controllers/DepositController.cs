using Microsoft.AspNetCore.Mvc;
using Stoqa.ProductCatalog.ApplicationService.DTOs.DepositDtos;
using Stoqa.ProductCatalog.ApplicationService.Interfaces.ServicesContracts;
using Stoqa.ProductCatalog.Domain.Handlers.NotificationHandler;

namespace Stoqa.ProductCatalog.Controllers;

[Route("api/[Controller]")]
[ApiController]
public sealed class DepositController(
    IDepositCommandService depositCommandService) : ControllerBase
{
    [HttpPost("register_deposit")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IEnumerable<DomainNotification>))]
    public async Task<bool> Register([FromBody] DepositRegisterRequest depositRegisterRequest) =>
        await depositCommandService.RegisterAsync(depositRegisterRequest);
}