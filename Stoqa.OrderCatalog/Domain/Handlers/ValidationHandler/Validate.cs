using FluentValidation;
using FluentValidation.Results;
using Stoqa.OrderCatalog.Domain.Interface;


namespace Stoqa.OrderCatalog.Domain.Handlers.ValidationHandler;

public abstract class Validate<T> : AbstractValidator<T>, IValidate<T> where T : class
{
    private ValidationResult? _validationResult;
    private void CreateResult(T entity) => _validationResult ??= Validate(entity);
    private async Task CreateResultAsync(T entity) => _validationResult ??= await ValidateAsync(entity);

    private Dictionary<string, string> GetErrors() =>
        _validationResult!.Errors.ToDictionary(error
                => error.PropertyName,
            error => error.ErrorMessage);

    public async Task<ValidationResponse> ValidationAsync(T entity)
    {
        await CreateResultAsync(entity);
        return ValidationResponse.CreateResponse(GetErrors());
    }

    public ValidationResponse Validation(T entity)
    {
        CreateResult(entity);
        return ValidationResponse.CreateResponse(GetErrors());
    }
}