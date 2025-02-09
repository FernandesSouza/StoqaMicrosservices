using Microsoft.AspNetCore.Mvc;
using Stoqa.ProductCatalog.ApplicationService.DTOs.PackagingCompositionDtos;
using Stoqa.ProductCatalog.ApplicationService.DTOs.PackagingCompositionDtos.Request;
using Stoqa.ProductCatalog.ApplicationService.Interfaces.ServicesContracts;

namespace Stoqa.ProductCatalog.Controllers;

[Route("api/[Controller]")]
[ApiController]
public sealed class PackagingCompositionController(
    IPackagingCompositionCommandService packagingCompositionCommandService
) : ControllerBase
{
    [HttpPost("register_product")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<bool> RegisterProduct(
        [FromBody] PackagingCompositionRegisterRequest packagingCompositionRegisterRequest) =>
        await packagingCompositionCommandService.RegisterAsync(packagingCompositionRegisterRequest);
}