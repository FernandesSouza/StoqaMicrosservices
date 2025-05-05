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
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new AsyncEventingBasicConsumer(channel);

        consumer.ReceivedAsync += async (_, eventArgs) =>
        {
            var body = eventArgs.Body.ToArray();
            var contentString = Encoding.UTF8.GetString(body);
            var @event = JsonConvert.DeserializeObject<OrderInventoryMessage>(contentString);

            try
            {
                await ProcessMessage(@event!);
                await channel.BasicAckAsync(eventArgs.DeliveryTag, false, stoppingToken);
            }
            catch
            {
                await channel.BasicNackAsync(
                    eventArgs.DeliveryTag,
                    false,
                    requeue: false,
                    cancellationToken: stoppingToken);
            }
        };

        await channel.BasicConsumeAsync(
            RabbitCatalogNames.QueueNameConference,
            false, consumer,
            cancellationToken: stoppingToken);

        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(1000, stoppingToken);
        }
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