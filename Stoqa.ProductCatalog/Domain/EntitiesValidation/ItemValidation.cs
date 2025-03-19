using Stoqa.ProductCatalog.Domain.Entities;
using Stoqa.ProductCatalog.Domain.Handlers.ValidationHandler;

namespace Stoqa.ProductCatalog.Domain.EntitiesValidation;

public sealed class ItemValidation : Validate<Item>
{
    public ItemValidation()
    {
        SetRules();
    }

    private void SetRules()
    {
    }
}