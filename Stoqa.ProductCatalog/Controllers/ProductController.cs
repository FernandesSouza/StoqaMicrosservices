using Microsoft.AspNetCore.Mvc;
using Stoqa.ProductCatalog.ApplicationService.Dtos.ProductDtos.Request;
using Stoqa.ProductCatalog.ApplicationService.DTOs.ProductDtos.Response;
using Stoqa.ProductCatalog.ApplicationService.Interfaces.ServicesContracts;

namespace Stoqa.ProductCatalog.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class ProductController(
    IProductCommandService productCommandService,
    IProductQueryService productQueryService
) : ControllerBase
{
    [HttpPost("register_product")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<bool> RegisterProduct([FromBody] ProductRegisterRequestDto productRegisterRequestDto) =>
        await productCommandService.RegisterAsync(productRegisterRequestDto);

    [HttpGet("find_all_products")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<List<ProductSimpleResponse>> FindAllProduct() =>
        await productQueryService.FindAllAsync();
}