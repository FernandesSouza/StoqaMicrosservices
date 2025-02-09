using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Stoqa.ProductCatalog.ApplicationService.DTOs.RabbitDtos;
using Stoqa.ProductCatalog.ApplicationService.RabbitMqService.Constants;

namespace Stoqa.ProductCatalog.ApplicationService.RabbitMqService;

public class OrderConsumer : BackgroundService
{
    private readonly IConfiguration _configuration;
    private IChannel _channel;
    public IServiceProvider ServiceProvider;
    private ILogger<OrderConsumer> _logger;

    public OrderConsumer(
        IConfiguration configuration,
        IChannel channel,
        IServiceProvider serviceProvider, ILogger<OrderConsumer> logger)
    {
        _configuration = configuration;
        _channel = channel;
        ServiceProvider = serviceProvider;
        _logger = logger;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new AsyncEventingBasicConsumer(_channel);

        consumer.ReceivedAsync += async (sender, eventArgs) =>
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

    private async Task ProcessMessage(OrderInventoryMessage @event)
    {
        _logger.LogInformation(@event.Code);
    }
}