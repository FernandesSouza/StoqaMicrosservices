using RabbitMQ.Client;
using Stoqa.ProductCatalog.ApplicationService.RabbitMqService.Constants;

namespace Stoqa.ProductCatalog.ApplicationService.RabbitMqService;

public static class RabbitProductConnection
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

        services.AddSingleton(channel);
    }
}