using FormatTCC.Application.Commands.AddUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FormatTCC.API.Controllers
{

    [Route("api/User")]
    public class UserController : Controller
    {

        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] AddUserCommand command)
        {

            var result = await mediator.Send(command);

            if (result.IsValid())
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

    }
}
