using FormatTCC.Application.Models.ViewModels;
using MediatR;

namespace FormatTCC.Application.Commands.AddUser
{
    public class AddUserCommand : IRequest<InputResultViewModel<object>>
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmedPassword { get; set; }
    }
}
