using Stoqa.ProductCatalog.Domain.Entities;
using Stoqa.ProductCatalog.Domain.Handlers.ValidationHandler;

namespace Stoqa.ProductCatalog.Domain.EntitiesValidation;

public sealed class StockItemValidation : Validate<StockItem>
{
    public StockItemValidation()
    {
        SetRules();
    }

    private void SetRules()
    {
    }
}