using FluentValidation;
using Stoqa.ProductCatalog.Domain.Entities;
using Stoqa.ProductCatalog.Domain.Enums;
using Stoqa.ProductCatalog.Domain.Extensions;
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
        RuleFor(i => i.SerialCode)
            .NotEmpty().WithMessage(EMessage.Required.GetDescription().FormatTo("SerialCode"))
            .Must(name => !string.IsNullOrWhiteSpace(name))
            .WithMessage("Codígo serial não pode conter apenas espaços.");
    }
}