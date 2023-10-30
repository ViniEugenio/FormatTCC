using FormatTCC.Application.Models.ViewModels;
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

                var inputResult = new InputResultViewModel("As informações de entrada não são válidas", errors);
                context.Result = new BadRequestObjectResult(inputResult);

            }

        }

    }
}

public static class ModelStateExtensions
{

    public static string[] GetErrorsMessages(this ModelStateDictionary modelState)
    {

        return modelState
            .Select(model => model.Value.Errors.Last())
            .Select(error => error.ErrorMessage)
            .ToArray();

    }

}