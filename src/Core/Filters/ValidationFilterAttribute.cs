using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Core
{
    public class ValidationFilterAttribute : IActionFilter
    {
        private readonly ILoggerManager _logger;

        public ValidationFilterAttribute(ILoggerManager logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var action = context.RouteData.Values["action"];
            var controller = context.RouteData.Values["controller"];

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            var param = context.ActionArguments
                .SingleOrDefault(x => x.Value.ToString()
                .Contains("Request")).Value;
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            if (param is null)
            {
                _logger.LogError($"Object sent from client is null. Controller: {controller}, " +
                    $"action: {action}");

                context.Result = new BadRequestObjectResult($"Object is null. Controller: {controller}, action: {action}");
                return;
            }
            if (!context.ModelState.IsValid)
            {
                _logger.LogError($"Invalid model state for the object. Controller: {controller}, action: {action}");
                context.Result = new UnprocessableEntityObjectResult(context.ModelState);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
