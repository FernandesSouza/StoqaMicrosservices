using FluentValidation;
using Stoqa.ProductCatalog.Domain.Entities;
using Stoqa.ProductCatalog.Domain.Enums;
using Stoqa.ProductCatalog.Domain.Extensions;
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
        RuleFor(i => i.DepositName)
            .NotEmpty().WithMessage(EMessage.Required.GetDescription().FormatTo("DepositName"))
            .Must(name => !string.IsNullOrWhiteSpace(name))
            .WithMessage("Nome do depósito não pode conter apenas espaços.");

        RuleFor(i => i.Identifier)
            .NotEmpty().WithMessage(EMessage.Required.GetDescription().FormatTo("Identifier"))
            .Must(name => !string.IsNullOrWhiteSpace(name))
            .WithMessage("Codígo identificador não pode conter apenas espaços.");
    }
}