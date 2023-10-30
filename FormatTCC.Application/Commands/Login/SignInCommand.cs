using FormatTCC.Application.Models.ViewModels;
using MediatR;

namespace FormatTCC.Application.Commands.Login
{
    public class SignInCommand : IRequest<InputResultViewModel>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
