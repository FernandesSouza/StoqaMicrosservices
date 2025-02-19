using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Stoqa.ProductCatalog.ApplicationService.DTOs.RabbitDtos;
using Stoqa.ProductCatalog.ApplicationService.RabbitMqService.Constants;

namespace Stoqa.ProductCatalog.ApplicationService.RabbitMqService.Consumers;

public class OrderConsumer : BackgroundService
{
    private IChannel _channel;
    private ILogger<OrderConsumer> _logger;

    public OrderConsumer(
        IChannel channel,
        ILogger<OrderConsumer> logger)
    {
        _channel = channel;
        _logger = logger;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new AsyncEventingBasicConsumer(_channel);

        consumer.ReceivedAsync += async (_, eventArgs) =>
        {
            var body = eventArgs.Body.ToArray();
            var contentString = Encoding.UTF8.GetString(body);
            var @event = JsonConvert.DeserializeObject<OrderInventoryMessage>(contentString);

            await ProcessMessage(@event!);
            await _channel.BasicAckAsync(eventArgs.DeliveryTag, false, stoppingToken);
        };

        _channel.BasicConsumeAsync(
            RabbitCatalogNames.QueueNameConference,
            false, consumer,
            cancellationToken: stoppingToken);

        return Task.CompletedTask;
    }

    //Falta logica do que fazer com a ordem
    private Task ProcessMessage(OrderInventoryMessage @event)
    {
       _logger.LogInformation(@event.Code);
       return Task.CompletedTask;
    }
}