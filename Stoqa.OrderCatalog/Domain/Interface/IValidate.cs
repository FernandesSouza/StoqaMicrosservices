
using ValidationResponse = Stoqa.OrderCatalog.Domain.Handlers.ValidationHandler.ValidationResponse;

namespace Stoqa.OrderCatalog.Domain.Interface;

public interface IValidate<in T> where T : class
{
    Task<ValidationResponse> ValidationAsync(T entity);
    ValidationResponse Validation(T entity);
}