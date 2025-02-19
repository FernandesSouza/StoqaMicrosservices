using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Stoqa.OrderCatalog.ApplicationService.RabbitMq.Constants;
using Stoqa.OrderCatalog.Domain.Entities;
using Stoqa.OrderCatalog.Infraestrutura.Interfaces.Repository;

namespace Stoqa.OrderCatalog.ApplicationService.RabbitMq.Consumers;

public class ProductConsumer(
    IChannel channel,
    IServiceScopeFactory serviceScopeFactory) : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new AsyncEventingBasicConsumer(channel);

        consumer.ReceivedAsync += async (_, eventArgs) =>
        {
            var body = eventArgs.Body.ToArray();
            var contentString = Encoding.UTF8.GetString(body);
            var @event = JsonConvert.DeserializeObject<Product>(contentString);

            await ProcessMessage(@event!);
            await channel.BasicAckAsync(eventArgs.DeliveryTag, false, stoppingToken);
        };

        channel.BasicConsumeAsync(
            RabbitCatalogNames.QueueProductRegisterSync,
            false, consumer,
            cancellationToken: stoppingToken);

        return Task.CompletedTask;
    }

    private async Task ProcessMessage(Product @event)
    {
        @event.Id = 0;
        using var scope = serviceScopeFactory.CreateScope();
        var productRepository = scope.ServiceProvider.GetRequiredService<IProductRepository>();

        await productRepository.SaveAsync(@event);
    }
}