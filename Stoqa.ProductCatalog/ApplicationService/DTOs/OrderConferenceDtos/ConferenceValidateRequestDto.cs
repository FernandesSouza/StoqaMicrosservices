namespace Stoqa.ProductCatalog.ApplicationService.DTOs.OrderConferenceDtos;

//TODO: FALTA CRIAR FLUXO DA VALIDAÇÃO DOS ITENS
public sealed record ConferenceValidateRequestDto
{
    public required string SerialCode { get; init; }
    public long OrderId { get; init; }
}