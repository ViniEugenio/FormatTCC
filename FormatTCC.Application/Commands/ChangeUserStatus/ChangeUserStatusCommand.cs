using FormatTCC.Application.Models.ViewModels;
using MediatR;

namespace FormatTCC.Application.Commands.ChangeUserStatus
{
    public class ChangeUserStatusCommand : IRequest<InputResultViewModel<object>>
    {
        public Guid Id { get; set; }
    }
}
