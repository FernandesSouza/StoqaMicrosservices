using Stoqa.OrderCatalog.Domain.Entities;

namespace Stoqa.OrderCatalog.Domain.EntitiesValidation;

public sealed class OrderValidation : Handlers.ValidationHandler.Validate<Orders>
{
    public OrderValidation()
    {
        SetRules();
    }

    private void SetRules()
    {
    }
}