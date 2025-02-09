using Stoqa.ProductCatalog.ApplicationService.Dtos.ProductDtos.Request;
using Stoqa.ProductCatalog.ApplicationService.DTOs.ProductDtos.Response;
using Stoqa.ProductCatalog.Domain.Entities;

namespace Stoqa.ProductCatalog.ApplicationService.Interfaces.MapperContracts;

public interface IProductMapper
{
    Product DtoRegisterToDomain(ProductRegisterRequestDto productRegisterRequestDto);
    List<ProductSimpleResponse> DomainToSimpleResponseDto(List<Product> product);
}