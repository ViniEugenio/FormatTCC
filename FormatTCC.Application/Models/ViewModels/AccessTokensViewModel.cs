namespace FormatTCC.Application.Models.ViewModels
{
    public class AccessTokensViewModel
    {

        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public AccessTokensViewModel(string accessToken, string refreshToken)
        {
            AccessToken = accessToken;  
            RefreshToken = refreshToken;
        }

    }
}
