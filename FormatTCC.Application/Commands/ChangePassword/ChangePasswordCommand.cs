using FormatTCC.Application.Models.ViewModels;
using MediatR;

namespace FormatTCC.Application.Commands.ChangePassword
{
    public class ChangePasswordCommand : IRequest<InputResultViewModel<object>>
    {
        public required string CurrentPassword { get; set; }
        public required string NewPassword { get; set; }
    }
}
