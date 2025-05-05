using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Stoqa.OrderCatalog.Domain.Entities;

namespace Stoqa.OrderCatalog.ApplicationService.RabbitMq.Consumers;

public sealed class DlqConsumer(
    IChannel channel
) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new AsyncEventingBasicConsumer(channel);

        consumer.ReceivedAsync += async (_, eventArgs) =>
        {
            var body = eventArgs.Body.ToArray();
            var contentString = Encoding.UTF8.GetString(body);
            var @event = JsonConvert.DeserializeObject<Product>(contentString);

            await ReProcessingMessageToQueue(@event!, eventArgs);
        };

        await channel.BasicConsumeAsync(
            "fila.deadletter",
            false, consumer,
            cancellationToken: stoppingToken);

        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(1000, stoppingToken);
        }
    }

    private async Task ReProcessingMessageToQueue(Product @event, BasicDeliverEventArgs eventArgs)
    {
        if (eventArgs.BasicProperties.Headers?["x-death"] is List<object> { Count: > 0 } xDeath)
        {
            var deathEntry = xDeath[0] as IDictionary<string, object>;
            var routingKeys = deathEntry!["routing-keys"] as List<object>;
            var originalRoutingKey = Encoding.UTF8.GetString((byte[])routingKeys![0]);

            var jsonMessage = JsonConvert.SerializeObject(@event);

            var messageBodyBytes = Encoding.UTF8.GetBytes(jsonMessage);

            Console.WriteLine($"MENSAGEM DE REENVIO NA DLQ: {jsonMessage} com routingKey: {originalRoutingKey}");
            await channel.BasicPublishAsync(
               "",
               originalRoutingKey,
                false, messageBodyBytes);
        }
    }
}