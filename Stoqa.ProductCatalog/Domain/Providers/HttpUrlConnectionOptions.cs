namespace Stoqa.ProductCatalog.Domain.Providers;

public class HttpUrlConnectionOptions
{
    public const string SectionName = "HttpUrlRequests";
    public required string ProductPost { get; init; }
}