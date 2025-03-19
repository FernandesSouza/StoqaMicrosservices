using Stoqa.ProductCatalog.ApplicationService.DTOs.DepositDtos;
using Stoqa.ProductCatalog.Domain.Entities;

namespace Stoqa.ProductCatalog.ApplicationService.Interfaces.MapperContracts;

public interface IDepositMapper
{
    Deposit DtoRegisterToDomain(DepositRegisterRequest depositRegisterRequest);
}