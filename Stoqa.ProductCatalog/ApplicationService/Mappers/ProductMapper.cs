using Stoqa.ProductCatalog.ApplicationService.Dtos.ProductDtos.Request;
using Stoqa.ProductCatalog.ApplicationService.DTOs.ProductDtos.Response;
using Stoqa.ProductCatalog.ApplicationService.Interfaces.MapperContracts;
using Stoqa.ProductCatalog.Domain.Entities;

namespace Stoqa.ProductCatalog.ApplicationService.Mappers;

public sealed class ProductMapper : IProductMapper
{
    public Product DtoRegisterToDomain(ProductRegisterRequestDto productRegisterRequestDto) =>
        new()
        {
            Price = productRegisterRequestDto.Price,
            CreateDate = productRegisterRequestDto.CreateDate,
            Name = productRegisterRequestDto.Name,
            Active = productRegisterRequestDto.Active,
            Description = productRegisterRequestDto.Description,
            Code = productRegisterRequestDto.Code,
        };


    public List<ProductSimpleResponse> DomainToSimpleResponseDto(List<Product> product) =>
        product.Select(SingleToSimpleResponse).ToList();

    private ProductSimpleResponse SingleToSimpleResponse(Product product) =>
        new()
        {
            Price = product.Price,
            CreateDate = product.CreateDate,
            Name = product.Name,
            Active = product.Active,
            Description = product.Description,
            Code = product.Code,
        };
}