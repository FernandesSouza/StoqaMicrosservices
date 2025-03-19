using Stoqa.ProductCatalog.ApplicationService.DTOs.DepositDtos;
using Stoqa.ProductCatalog.ApplicationService.Interfaces.MapperContracts;
using Stoqa.ProductCatalog.ApplicationService.Interfaces.ServicesContracts;
using Stoqa.ProductCatalog.Domain.Entities;
using Stoqa.ProductCatalog.Domain.Interfces;
using Stoqa.ProductCatalog.Infraestrutura.Interfaces.RepositoryContracts;

namespace Stoqa.ProductCatalog.ApplicationService.Services.DepositService;

public sealed class DepositCommandService(
    INotficationHandler notificationHandler,
    IValidate<Deposit> validate,
    IDepositMapper depositMapper,
    IDepositRepository depositRepository
    ) : BaseService<Deposit>(notificationHandler, validate), IDepositCommandService
{
    public async Task<bool> RegisterAsync(DepositRegisterRequest depositRegisterRequest)
    {
        var domain = depositMapper.DtoRegisterToDomain(depositRegisterRequest);

        if (!await EntityValidationAsync(domain))
            return false;

        return await depositRepository.SaveAsync(domain);
    }
}