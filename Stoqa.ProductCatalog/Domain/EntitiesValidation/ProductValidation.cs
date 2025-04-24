using FluentValidation;
using Stoqa.ProductCatalog.Domain.Entities;
using Stoqa.ProductCatalog.Domain.Enums;
using Stoqa.ProductCatalog.Domain.Extensions;
using Stoqa.ProductCatalog.Domain.Handlers.ValidationHandler;

namespace Stoqa.ProductCatalog.Domain.EntitiesValidation;

public sealed class ProductValidation : Validate<Product>
{
    public ProductValidation()
    {
        SetRules();
    }

    private void SetRules()
    {
        RuleFor(p => p.Price)
            .NotNull()
            .WithMessage(EMessage.Required.GetDescription().FormatTo("Price"))
            .GreaterThanOrEqualTo(0)
            .WithMessage(EMessage.InvalidValue.GetDescription().FormatTo("Price"));

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage(EMessage.Required.GetDescription().FormatTo("Name"))
            .Must(name => !string.IsNullOrWhiteSpace(name)).WithMessage("Nome não pode conter apenas espaços.");

        RuleFor(p => p.Description)
            .NotEmpty().WithMessage(EMessage.Required.GetDescription().FormatTo("Description"))
            .Must(name => !string.IsNullOrWhiteSpace(name)).WithMessage("Nome técnico não pode conter apenas espaços.");

        RuleFor(p => p.Code)
            .NotEmpty()
            .WithMessage("Código não pode conter apenas espaços");
    }
}