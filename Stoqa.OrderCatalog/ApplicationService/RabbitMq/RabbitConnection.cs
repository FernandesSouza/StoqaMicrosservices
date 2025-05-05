using Polly;
using Polly.Contrib.WaitAndRetry;
using Polly.Retry;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using Stoqa.OrderCatalog.ApplicationService.RabbitMq.Constants;

namespace Stoqa.OrderCatalog.ApplicationService.RabbitMq;

public static class RabbitConnection
{
    public static async Task RabbitFactory(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("RabbitPort");

        var factory = new ConnectionFactory
        {
            Uri = new Uri(connectionString!),
            UserName = RabbitCatalogNames.UserName,
            Password = RabbitCatalogNames.Password,
            HostName = RabbitCatalogNames.HostName
        };

        var policy = GetRetryPolicy();
        var connection = await policy.ExecuteAsync(() => factory.CreateConnectionAsync());

        var channel = await connection.CreateChannelAsync();
        var args = new Dictionary<string, object>
        {
            ["x-dead-letter-exchange"] = "dlx.exchange",
            ["x-dead-letter-routing-key"] = "dlq.routingkey"
        };

        await channel.ExchangeDeclareAsync(exchange: "dlx.exchange", type: ExchangeType.Direct, durable: true, autoDelete: false, arguments: null);
        await channel.QueueDeclareAsync(queue: "fila.deadletter", durable: true, exclusive: false, autoDelete: false, arguments: null);
        await channel.QueueBindAsync(queue: "fila.deadletter", exchange: "dlx.exchange", routingKey: "dlq.routingkey", arguments: null);

        await channel.ExchangeDeclareAsync(RabbitCatalogNames.ExchangeNameProduct, ExchangeType.Topic);
        await channel.ExchangeDeclareAsync(RabbitCatalogNames.ExchangeName, ExchangeType.Topic);

        await channel.QueueDeclareAsync(RabbitCatalogNames.QueueProductRegisterSync, true, false, arguments: args!);
        await channel.QueueBindAsync(RabbitCatalogNames.QueueProductRegisterSync,
            RabbitCatalogNames.ExchangeNameProduct,
            RabbitCatalogNames.ProductRegisterSyncKey, arguments: args!);

        await channel.QueueDeclareAsync(RabbitCatalogNames.QueueProductActiveOrActiveSync, true, false, arguments: args!);
        await channel.QueueBindAsync(RabbitCatalogNames.QueueProductActiveOrActiveSync,
            RabbitCatalogNames.ExchangeNameProduct,
            RabbitCatalogNames.ProductActiveOrActiveSyncKey, arguments: args!);

        await channel.QueueDeclareAsync(RabbitCatalogNames.QueueNameConference, true, false, arguments: args!);
        await channel.QueueBindAsync(RabbitCatalogNames.QueueNameConference, RabbitCatalogNames.ExchangeName,
            RabbitCatalogNames.ConferenceKey, arguments: args!);

        services.AddSingleton(channel);
    }

    private static AsyncRetryPolicy GetRetryPolicy()
    {
        return Policy
            .Handle<BrokerUnreachableException>()
            .Or<OperationInterruptedException>()
            .Or<Exception>(ex => ex.Message.Contains("connection"))
            .WaitAndRetryAsync(
                Backoff.ExponentialBackoff(TimeSpan.FromSeconds(10), 5),
                (exception, timeSpan, retryCount, context) =>
                {
                    Console.WriteLine(
                        $"Tentativa {retryCount} de conectar ao RabbitMQ falhou. Tentando novamente em {timeSpan.TotalSeconds} segundos.");
                });
    }
}