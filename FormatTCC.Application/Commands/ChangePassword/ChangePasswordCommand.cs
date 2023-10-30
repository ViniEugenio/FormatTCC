using FormatTCC.Application.Models.ViewModels;
using MediatR;

namespace FormatTCC.Application.Commands.ChangePassword
{
    public class ChangePasswordCommand : IRequest<InputResultViewModel>
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
