using Stoqa.ProductCatalog.Domain.Entities;
using Stoqa.ProductCatalog.Domain.EntitiesValidation;
using Stoqa.ProductCatalog.Domain.Interfces;

namespace Stoqa.ProductCatalog.Ioc.Container;

public static class ValidationContainer
{
    public static IServiceCollection AddValidationContainer(this IServiceCollection service) =>
        service.AddScoped<IValidate<Product>, ProductValidation>()
            .AddScoped<IValidate<Item>, ItemValidation>()
            .AddScoped<IValidate<StockItem>, StockItemValidation>()
            .AddScoped<IValidate<Deposit>, DepositValidation>();
}