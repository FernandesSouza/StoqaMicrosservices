using Stoqa.ProductCatalog.ApplicationService.Dtos.ProductDtos.Request;
using Stoqa.ProductCatalog.ApplicationService.Interfaces.MapperContracts;
using Stoqa.ProductCatalog.ApplicationService.Interfaces.ServicesContracts;
using Stoqa.ProductCatalog.ApplicationService.Services.ObserverNotification;
using Stoqa.ProductCatalog.Domain.Entities;
using Stoqa.ProductCatalog.Domain.Enums;
using Stoqa.ProductCatalog.Domain.Interfces;
using Stoqa.ProductCatalog.Infraestrutura.Interfaces.RepositoryContracts;

namespace Stoqa.ProductCatalog.ApplicationService.Services.ProductService;

public sealed class ProductCommandService(
    IProductRepository productRepository,
    IProductMapper productMapper,
    INotficationHandler notificationHandler,
    IValidate<Product> validate,
    ProductNotifier productNotifier)
    : BaseService<Product>(
        notificationHandler, validate), IProductCommandService
{
    public async Task<bool> RegisterAsync(ProductRegisterRequestDto productRegister)
    {
        var product = productMapper.DtoRegisterToDomain(productRegister);

        if (!await EntityValidationAsync(product))
            return false;

        var result = await productRepository.SaveAsync(product);

        if (!result) return false;
        await productNotifier.NotificationCreateObserversAsync(new ProductEvent
        {
            ProductTypeEvent = EProductTypeEvent.Created,
            Product = product
        });
        return true;
    }
}