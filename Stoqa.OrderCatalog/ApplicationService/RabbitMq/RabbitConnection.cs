using RabbitMQ.Client;
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
            Password = RabbitCatalogNames.Password
        };

        var connection = await factory.CreateConnectionAsync();

        var channel = await connection.CreateChannelAsync();
        await channel.ExchangeDeclareAsync(RabbitCatalogNames.ExchangeName, ExchangeType.Topic);

        await channel.QueueDeclareAsync(RabbitCatalogNames.QueueNameConference, true, false);
        await channel.QueueBindAsync(RabbitCatalogNames.QueueNameConference, RabbitCatalogNames.ExchangeName,
            RabbitCatalogNames.ConferenceKey);

        await channel.ExchangeDeclareAsync(RabbitCatalogNames.ExchangeNameProduct, ExchangeType.Topic);

        await channel.QueueDeclareAsync(RabbitCatalogNames.QueueProductRegisterSync, true, false);
        await channel.QueueBindAsync(RabbitCatalogNames.QueueProductRegisterSync,
            RabbitCatalogNames.ExchangeNameProduct,
            RabbitCatalogNames.ProductRegisterSyncKey);

        services.AddSingleton(channel);
    }
}