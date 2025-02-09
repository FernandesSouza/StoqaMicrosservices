using Microsoft.Extensions.Options;
using Stoqa.ProductCatalog.ApplicationService.Dtos.ProductDtos.Request;
using Stoqa.ProductCatalog.ApplicationService.Interfaces.ObserverContracts;
using Stoqa.ProductCatalog.Domain.Enums;
using Stoqa.ProductCatalog.Domain.Providers;

namespace Stoqa.ProductCatalog.ApplicationService.Services.ProductService;

public sealed class ProductSyncService(
    HttpClient client,
    IOptions<HttpUrlConnectionOptions> options)
    : IProductObserver
{
    private readonly string _productPostUrl = options.Value.ProductPost;

    public async Task HandleCreateEventAsync(ProductEvent productEvent)
    {
        if (productEvent.ProductTypeEvent == EProductTypeEvent.Created)
            await client.PostAsJsonAsync(_productPostUrl, productEvent.Product);
    }
}