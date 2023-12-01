using FormatTCC.Application.Models.ViewModels;
using MediatR;

namespace FormatTCC.Application.Queries.GetUserList
{
    public class GetUserListQuery : IRequest<List<UserInfoViewModel>>
    {

        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public DateTime StartRegistrationDate { get; set; } = DateTime.MinValue;
        public DateTime EndRegistrationDate { get; set; } = DateTime.MinValue;
        public bool Active { get; set; } = true;

    }
}
