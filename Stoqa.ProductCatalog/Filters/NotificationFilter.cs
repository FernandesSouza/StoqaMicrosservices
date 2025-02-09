using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Stoqa.ProductCatalog.Domain.Interfces;

namespace Stoqa.ProductCatalog.Filters;

public sealed class NotificationFilter(
    INotficationHandler notificationHandler) : ActionFilterAttribute
{
    private const string MethodGet = "Get";

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.HttpContext.Request.Method != MethodGet && notificationHandler.HasNotification())
            context.Result = new BadRequestObjectResult(notificationHandler.GetNotifications());

        base.OnActionExecuted(context);
    }
}