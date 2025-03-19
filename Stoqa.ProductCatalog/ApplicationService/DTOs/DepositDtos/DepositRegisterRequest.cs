namespace Stoqa.ProductCatalog.ApplicationService.DTOs.DepositDtos;

public sealed record DepositRegisterRequest
{
    public required string DepositName { get; set; }
    public required string Identifier { get; init; }
    public bool Active { get; set; }
}