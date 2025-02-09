using Microsoft.EntityFrameworkCore;
using Stoqa.ProductCatalog.ApplicationService.DTOs.ProductDtos.Response;
using Stoqa.ProductCatalog.ApplicationService.Interfaces.MapperContracts;
using Stoqa.ProductCatalog.ApplicationService.Interfaces.ServicesContracts;
using Stoqa.ProductCatalog.Infraestrutura.Interfaces.RepositoryContracts;

namespace Stoqa.ProductCatalog.ApplicationService.Services.ProductService;

public sealed class ProductQueryService(
    IProductRepository productRepository,
    IProductMapper productMapper) : IProductQueryService
{
    public async Task<List<ProductSimpleResponse>> FindAllAsync()
    {
        var productList = await productRepository.FindAllAsync(
            p => p.Include(pk => pk.PackingCompositions));

        return productList.Count > 0
            ? productMapper.DomainToSimpleResponseDto(productList)
            : [];
    }
}