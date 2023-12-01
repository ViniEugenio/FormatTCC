using FormatTCC.Application.Models.ViewModels;
using MediatR;

namespace FormatTCC.Application.Commands.RefreshAccessToken
{
    public class RefreshAccessTokenCommand : IRequest<InputResultViewModel<AccessTokensViewModel>>
    {
        public required string AccessToken { get; set; }
        public required string RefreshToken { get; set; }
    }
}
