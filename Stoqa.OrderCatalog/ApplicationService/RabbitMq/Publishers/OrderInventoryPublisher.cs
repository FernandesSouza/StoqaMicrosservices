using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using Stoqa.OrderCatalog.ApplicationService.DTOs.OrderSaleDtos;
using Stoqa.OrderCatalog.ApplicationService.Interfaces.Service;
using Stoqa.OrderCatalog.ApplicationService.RabbitMq.Constants;

namespace Stoqa.OrderCatalog.ApplicationService.RabbitMq.Publishers;

public sealed class OrderInventoryPublisher(
    IChannel channel
) : IOrderInventoryPublisher
{
    public async Task PublishOrder(OrderInventoryMessage message)
    {
        var jsonMessage = JsonConvert.SerializeObject(message);

        var messageBodyBytes = Encoding.UTF8.GetBytes(jsonMessage);

        await channel.BasicPublishAsync(
            RabbitCatalogNames.ExchangeName,
            RabbitCatalogNames.ConferenceKey,
            false, messageBodyBytes);
    }
}