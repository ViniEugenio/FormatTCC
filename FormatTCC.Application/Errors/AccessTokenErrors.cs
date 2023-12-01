namespace FormatTCC.Application.Errors
{
    public static class AccessTokenErrors
    {

        public readonly static string AccessTokenEmpty = "O token de acesso não pode ser vazio";
        public readonly static string RefreshTokenEmpty = "O token de atualização não pode ser vazio";
        public readonly static string InvalidToken = "O tokens informados para atualização não são válidos";

    }
}
