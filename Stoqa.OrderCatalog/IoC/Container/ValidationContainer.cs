using Stoqa.OrderCatalog.Domain.Entities;
using Stoqa.OrderCatalog.Domain.EntitiesValidation;
using Stoqa.OrderCatalog.Domain.Interface;


namespace Stoqa.OrderCatalog.IoC.Container;

public static class ValidationContainer
{
    public static IServiceCollection AddValidations(this IServiceCollection service) =>
        service.AddScoped<IValidate<Orders>, OrderValidation>();
}