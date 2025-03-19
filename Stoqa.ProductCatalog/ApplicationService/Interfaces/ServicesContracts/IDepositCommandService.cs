using Stoqa.ProductCatalog.ApplicationService.DTOs.DepositDtos;

namespace Stoqa.ProductCatalog.ApplicationService.Interfaces.ServicesContracts;

public interface IDepositCommandService
{
    Task<bool> RegisterAsync(DepositRegisterRequest depositRegisterRequest);
}