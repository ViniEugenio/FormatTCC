using FormatTCC.Application.Commands.AddUser;
using FormatTCC.Application.Commands.ChangePassword;
using FormatTCC.Application.Commands.Login;
using FormatTCC.Application.Commands.SignInOut;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FormatTCC.API.Controllers
{

    [Route("api/User")]
    [Authorize]
    public class UserController : BaseController
    {

        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUser([FromBody] AddUserCommand command)
        {

            var result = await mediator.Send(command);
            return RespondInput(result);

        }

        [HttpPost("SignIn")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] SignInCommand command)
        {

            var result = await mediator.Send(command);
            return RespondInput(result);

        }

        [HttpPost("SignOut")]
        public async Task<IActionResult> LogOut()
        {

            var result = await mediator.Send(new SignOutCommand());
            return RespondInput(result);

        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand command)
        {

            var result = await mediator.Send(command);
            return RespondInput(result);

        }

        [HttpGet]
        public async Task<IActionResult> GetUserInfo()
        {
            return Ok("Informações do usuário logado");
        }

    }
}
