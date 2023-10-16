using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FormatTCC.API.Filters
{
    public class ModelStateValidatorFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

            if (!context.ModelState.IsValid)
            {

                var errors = context.ModelState.GetErrorsMessages();
                context.Result = new BadRequestObjectResult(errors);

            }

        }

    }
}

public static class ModelStateExtensions
{

    public static List<string> GetErrorsMessages(this ModelStateDictionary modelState)
    {

        return modelState
            .SelectMany(model => model.Value.Errors)
            .Select(error => error.ErrorMessage)
            .ToList();

    }

}