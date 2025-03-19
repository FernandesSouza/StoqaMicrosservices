using Stoqa.ProductCatalog.Domain.Entities;
using Stoqa.ProductCatalog.Domain.Handlers.ValidationHandler;

namespace Stoqa.ProductCatalog.Domain.EntitiesValidation;

public sealed class DepositValidation : Validate<Deposit>
{
    public DepositValidation()
    {
        SetRules();
    }

    private void SetRules()
    {
    }
}