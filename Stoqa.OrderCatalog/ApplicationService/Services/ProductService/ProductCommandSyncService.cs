using Stoqa.OrderCatalog.ApplicationService.DTOs.ProductDtos;
using Stoqa.OrderCatalog.ApplicationService.Interfaces.Mapper;
using Stoqa.OrderCatalog.ApplicationService.Interfaces.Service;
using Stoqa.OrderCatalog.Infraestrutura.Interfaces.Repository;

namespace Stoqa.OrderCatalog.ApplicationService.Services.ProductService;

public sealed class ProductCommandSyncService(
    IProductRepository productRepository,
    IProductMapper productMapper
) : IProductCommandSyncService
{
    public async Task<bool> RegisterAsync(ProductRegisterSyncRequest registerSyncRequest)
    {
        var product = productMapper.DtoRegisterToDomain(registerSyncRequest);
        return await productRepository.SaveAsync(product);
    }
}