using FormatTCC.Application.Models.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FormatTCC.API.Controllers
{

    public abstract class BaseController : Controller
    {

        private readonly IMediator mediator;

        public BaseController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        protected async Task<IActionResult> RespondInput<T>(IRequest<InputResultViewModel<T>> command) where T : class
        {

            var result = await mediator.Send(command);

            if (result.IsValid())
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        protected async Task<IActionResult> RespondQuery<T>(IRequest<T> query)
        {
            return Ok(await mediator.Send(query));
        }

    }

}
