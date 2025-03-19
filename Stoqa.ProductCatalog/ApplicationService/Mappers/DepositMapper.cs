using Stoqa.ProductCatalog.ApplicationService.DTOs.DepositDtos;
using Stoqa.ProductCatalog.ApplicationService.Interfaces.MapperContracts;
using Stoqa.ProductCatalog.Domain.Entities;

namespace Stoqa.ProductCatalog.ApplicationService.Mappers;

public sealed class DepositMapper : IDepositMapper
{
    public Deposit DtoRegisterToDomain(DepositRegisterRequest depositRegisterRequest) =>
        new()
        {
            DepositName = depositRegisterRequest.DepositName,
            Identifier = depositRegisterRequest.Identifier,
            Active = depositRegisterRequest.Active,
        };

}