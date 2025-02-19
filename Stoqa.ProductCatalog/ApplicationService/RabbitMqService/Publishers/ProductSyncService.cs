using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using Stoqa.ProductCatalog.ApplicationService.Interfaces.ServicesContracts;
using Stoqa.ProductCatalog.ApplicationService.RabbitMqService.Constants;
using Stoqa.ProductCatalog.Domain.Entities;

namespace Stoqa.ProductCatalog.ApplicationService.RabbitMqService.Publishers;

public sealed class ProductSyncService(
    IChannel channel)
    : IProductSyncService
{
    public async Task SyncToProductAsync(Product product)
    {
        var jsonMessage = JsonConvert.SerializeObject(product);
        var messageBytes = Encoding.UTF8.GetBytes(jsonMessage);

        await channel.BasicPublishAsync(
            RabbitCatalogNames.ExchangeNameProduct,
            RabbitCatalogNames.ProductRegisterSyncKey,
            false, messageBytes);
    }
}