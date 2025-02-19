namespace Stoqa.ProductCatalog.ApplicationService.RabbitMqService.Constants;

public static class RabbitCatalogNames
{
    public const string UserName = "guest";
    public const string Password = "guest";
    
    public const string ExchangeName = "Order-Sale";
    public const string ExchangeNameProduct = "Product-Sync";

    public const string QueueNameConference = "StoqaQueueConference";
    public const string ConferenceKey = "Conference-key";

    public const string QueueNameConferenceCompleted = "StoqaQueueConferenceCompleted";
    public const string ConferenceKeyCompleted = "ConferenceCompletede-Key";

    public const string QueueProductRegisterSync = "ProductRegisterQueueSync";
    public const string ProductRegisterSyncKey = "ProductSync-Key";
}