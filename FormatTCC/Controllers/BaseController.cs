using FormatTCC.Application.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FormatTCC.API.Controllers
{

    public abstract class BaseController : Controller
    {

        protected IActionResult RespondInput(InputResultViewModel result)
        {

            if (result.IsValid())
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

    }

}
