namespace FormatTCC.Application.Helpers.Errors
{
    public static class UserErrors
    {

        public static string DuplicateEmail = "O email informado já está sendo usado por outro usuário";
        public static string CreateUserSuccess = "Usuário cadastro com sucesso";
        public static string CreateUserError = "Não foi possível cadastrar o usuário";
        public static string EmptyEmail = "O email não pode ser vazio";
        public static string InvalidEmail = "O email não é válido";
        public static string EmptyUserName = "O nome não pode ser vazio";
        public static string EmptyPassword = "A senha não pode ser vazia";
        public static string NotConfirmedPassword = "Por favor confirme sua senha";
        public static string ConfirmedPasswordInvalid = "As senhas informadas não são iguais";
        public static string MinimumPasswordLength = "A senha deve conter pelo menos 6 caracteres";

    }
}
