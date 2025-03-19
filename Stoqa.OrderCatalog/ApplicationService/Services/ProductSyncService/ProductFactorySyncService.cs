using Stoqa.OrderCatalog.ApplicationService.DTOs.ProductDtos;
using Stoqa.OrderCatalog.ApplicationService.Interfaces.Service;
using Stoqa.OrderCatalog.Domain.Enums;
using Stoqa.OrderCatalog.Infraestrutura.Interfaces.Repository;

namespace Stoqa.OrderCatalog.ApplicationService.Services.ProductSyncService;

public sealed class ProductFactorySyncService(
    IProductRepository productRepository) : IProductObserver
{
    public async Task HandleCreateEventAsync(ProductEventDto eventDto)
    {
        await (eventDto.ProductTypeEvent switch
        {
            EProductTypeEvent.Created => productRepository.SaveAsync(eventDto.Product!),
            EProductTypeEvent.Update => productRepository.UpdateAsync(eventDto.Product!),
            EProductTypeEvent.Delete => productRepository.DeleteAsync(p => p.Id == eventDto.ProductId),
            _ => Task.CompletedTask
        });
    }
}