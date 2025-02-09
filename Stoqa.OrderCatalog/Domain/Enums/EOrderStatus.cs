namespace Stoqa.OrderCatalog.Domain.Enums;

public enum EOrderStatus
{
    Created = 1,
    Conference,
    ConferenceCompleted,
    AwaitingConfirmed,
    InTransport,
    Finished
}