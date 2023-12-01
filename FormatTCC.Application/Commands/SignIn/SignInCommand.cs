using FormatTCC.Application.Models.ViewModels;
using MediatR;

namespace FormatTCC.Application.Commands.SignIn
{
    public class SignInCommand : IRequest<InputResultViewModel<AccessTokensViewModel>>
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}
