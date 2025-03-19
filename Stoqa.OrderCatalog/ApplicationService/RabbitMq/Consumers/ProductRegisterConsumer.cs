using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Stoqa.OrderCatalog.ApplicationService.DTOs.ProductDtos;
using Stoqa.OrderCatalog.ApplicationService.Interfaces.Service;
using Stoqa.OrderCatalog.ApplicationService.RabbitMq.Constants;
using Stoqa.OrderCatalog.ApplicationService.RabbitMq.ObserverNotification;
using Stoqa.OrderCatalog.Domain.Entities;
using Stoqa.OrderCatalog.Domain.Enums;

namespace Stoqa.OrderCatalog.ApplicationService.RabbitMq.Consumers;

public class ProductRegisterConsumer(
    IChannel channel,
    IServiceScopeFactory scopeFactory) : BackgroundService
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
        using var scope = scopeFactory.CreateScope();
        var observer = scope.ServiceProvider.GetRequiredService<ProductNotification>();
    
        await observer.NotificationCreateObserversAsync(new ProductEventDto
        {
            ProductTypeEvent = EProductTypeEvent.Created,
            Product = @event
        });
    }
}