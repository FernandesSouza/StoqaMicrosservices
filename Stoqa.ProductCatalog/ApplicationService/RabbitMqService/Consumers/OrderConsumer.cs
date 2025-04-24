using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Stoqa.ProductCatalog.ApplicationService.DTOs.RabbitDtos;
using Stoqa.ProductCatalog.ApplicationService.RabbitMqService.Constants;
using Stoqa.ProductCatalog.Infraestrutura.Interfaces.RepositoryContracts;

namespace Stoqa.ProductCatalog.ApplicationService.RabbitMqService.Consumers;

public class OrderConsumer(
    IChannel channel,
    IServiceScopeFactory scopeFactory
) : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new AsyncEventingBasicConsumer(channel);

        consumer.ReceivedAsync += async (_, eventArgs) =>
        {
            var body = eventArgs.Body.ToArray();
            var contentString = Encoding.UTF8.GetString(body);
            var @event = JsonConvert.DeserializeObject<OrderInventoryMessage>(contentString);

            await ProcessMessage(@event!);
            await channel.BasicAckAsync(eventArgs.DeliveryTag, false, stoppingToken);
        };

        channel.BasicConsumeAsync(
            RabbitCatalogNames.QueueNameConference,
            false, consumer,
            cancellationToken: stoppingToken);

        return Task.CompletedTask;
    }

    private async Task ProcessMessage(OrderInventoryMessage @event)
    {
        using var scope = scopeFactory.CreateScope();
        var stockItem = scope.ServiceProvider.GetRequiredService<IStockItemRepository>();

        if (@event.ProductOrders != null)
        {
            foreach (var po in @event.ProductOrders)
            {
                await stockItem.UpdateReservedAsync(st => st.ProductId == po.ProductId, po.QuantityOrdered);
            }
        }
    }
}