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

        await channel.ExchangeDeclareAsync(RabbitCatalogNames.ExchangeNameProduct, ExchangeType.Topic);
        await channel.ExchangeDeclareAsync(RabbitCatalogNames.ExchangeName, ExchangeType.Topic);

        await channel.QueueDeclareAsync(RabbitCatalogNames.QueueProductRegisterSync, true, false);
        await channel.QueueBindAsync(RabbitCatalogNames.QueueProductRegisterSync,
            RabbitCatalogNames.ExchangeNameProduct,
            RabbitCatalogNames.ProductRegisterSyncKey);

        await channel.QueueDeclareAsync(RabbitCatalogNames.QueueProductActiveOrActiveSync, true, false);
        await channel.QueueBindAsync(RabbitCatalogNames.QueueProductActiveOrActiveSync,
            RabbitCatalogNames.ExchangeNameProduct,
            RabbitCatalogNames.ProductActiveOrActiveSyncKey);

        await channel.QueueDeclareAsync(RabbitCatalogNames.QueueNameConference, true, false);
        await channel.QueueBindAsync(RabbitCatalogNames.QueueNameConference, RabbitCatalogNames.ExchangeName,
            RabbitCatalogNames.ConferenceKey);

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