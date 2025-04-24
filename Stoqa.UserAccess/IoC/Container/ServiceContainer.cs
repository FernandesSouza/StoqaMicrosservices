using Stoqa.Identity.ApplicationService.Interfaces;
using Stoqa.Identity.ApplicationService.Interfaces.ServiceContracts;
using Stoqa.Identity.ApplicationService.Services.TokenService;
using Stoqa.Identity.ApplicationService.Services.UserServices;
using Stoqa.Identity.Infraestrutura.Interface;
using Stoqa.Identity.Infraestrutura.Repository;

namespace Stoqa.Identity.IoC.Container;

public static class ServiceContainer
{
    public static IServiceCollection AddServiceContainer(this IServiceCollection service) =>
        service.AddScoped<IGenerateJwtToken, GenerateJwtToken>()
            .AddScoped<IUserQueryService, UserQueryService>()
            .AddScoped<IUserCommandService, UserCommandService>();
}