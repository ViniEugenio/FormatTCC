using FormatTCC.API.Filters;
using FormatTCC.Application.Commands.AddUser;
using FormatTCC.Application.Commands.ChangePassword;
using FormatTCC.Application.Commands.ChangeUserStatus;
using FormatTCC.Application.Commands.RefreshAccessToken;
using FormatTCC.Application.Commands.SignIn;
using FormatTCC.Application.Commands.SignInOut;
using FormatTCC.Application.Queries.GetUserInfo;
using FormatTCC.Application.Queries.GetUserList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FormatTCC.API.Controllers
{

    [Route("api/[controller]")]
    [Authorize]
    public class UserController : BaseController
    {

        public UserController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUser([FromBody] AddUserCommand command)
        {
            return await RespondInput(command);
        }

        [HttpPost("SignIn")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] SignInCommand command)
        {
            return await RespondInput(command);
        }

        [HttpPost("RefreshUserAccessToken")]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshUserAccessToken([FromBody] RefreshAccessTokenCommand command)
        {
            return await RespondInput(command);
        }

        [HttpPost("SignOut")]
        public async Task<IActionResult> LogOut()
        {
            return await RespondInput(new SignOutCommand());
        }

        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand command)
        {
            return await RespondInput(command);
        }

        [HttpGet("GetUserInfo")]
        public async Task<IActionResult> GetUserInfo()
        {
            return await RespondQuery(new GetuserQuery());
        }

        [HttpGet]
        [ClaimAuthorize("User", "List")]
        public async Task<IActionResult> GetUserList([FromQuery] GetUserListQuery query)
        {
            return await RespondQuery(query);
        }

        [HttpPatch("ChangeUserStatus")]
        [ClaimAuthorize("User", "Update")]
        public async Task<IActionResult> ChangeUserStatus([FromBody] ChangeUserStatusCommand command)
        {
            return await RespondInput(command);
        }

    }
}
