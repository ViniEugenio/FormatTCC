namespace FormatTCC.Application.Helpers.Errors
{
    public class UserErrors
    {

        public static string EmptyEmail = "O email não pode ser vazio";
        public static string InvalidEmailFormat = "O email não é válido";
        public static string EmptyUserName = "O nome não pode ser vazio";
        public static string EmptyPassword = "A senha não pode ser vazia";
        public static string NewEmptyPassword = "A nova senha não pode ser vazia";
        public static string NotConfirmedPassword = "Por favor confirme sua senha";
        public static string ConfirmedPasswordInvalid = "As senhas informadas não são iguais";
        public static string MinimumPasswordLength = "A senha deve conter pelo menos 6 caracteres";
        public static string EmptyName = "O nome não pode ser vazio";
        public static string EmptySurName = "O sobrenome não pode ser vazio";
        public static string LoginError = "Usuário ou senha inválidos";
        public static string UserAlreadyAuthenticated = "O usuário já está logado, por motivos de segurança você será deslogado";
        public static string NoOneUserAutheticated = "Nenhum usuário está logado no momento";
        public static string DefaultError = "Ocorreu um erro desconhecido.";
        public static string ConcurrencyFailure = "Falha de concorrência otimista, o objeto foi modificado.";
        public static string PasswordMismatch = "Senha incorreta.";
        public static string InvalidToken = "Token inválido.";
        public static string LoginAlreadyAssociated = "Já existe um usuário com este login.";
        public static string UserAlreadyHasPassword = "O usuário já possui uma senha definida.";
        public static string UserLockoutNotEnabled = "O lockout não está habilitado para este usuário.";
        public static string PasswordRequiresNonAlphanumeric = "As senhas devem conter ao menos um caracter não alfanumérico.";
        public static string PasswordRequiresDigit = "As senhas devem conter ao menos um digito ('0'-'9').";
        public static string PasswordRequiresLower = "As senhas devem conter ao menos um caracter em caixa baixa ('a'-'z').";
        public static string PasswordRequiresUpper = "As senhas devem conter ao menos um caracter em caixa alta ('A'-'Z').";

        public static string UserLockedError(string name, DateTimeOffset endDate)
        {

            TimeZoneInfo localTimeZone = TimeZoneInfo.Local;
            var dateTimeLocal = TimeZoneInfo.ConvertTime(endDate, localTimeZone).ToString("dd/MM/yyyy HH:mm:ss");

            return $"O usuário '{name}' está bloqueado por conta de várias tentativas de login malsucedidas, o fim do bloqueio do usuário será '{dateTimeLocal}'";

        }

        public static string InvalidUserName(string? userName) => $"O login '{userName}' é inválido, pode conter apenas letras ou dígitos.";
        public static string InvalidEmail(string? email) => $"O email '{email}' é inválido.";
        public static string DuplicateUserName(string userName) => $"O username '{userName}' já está sendo utilizado.";
        public static string DuplicateEmail(string email) => $"O email '{email}' já está sendo utilizado.";
        public static string InvalidRoleName(string? role) => $"A permissão '{role}' é inválida.";
        public static string DuplicateRoleName(string role) => $"A permissão '{role}' já está sendo utilizada.";
        public static string UserAlreadyInRole(string role) => $"O usuário já possui a permissão '{role}'.";
        public static string UserNotInRole(string role) => $"O usuário não tem a permissão '{role}'.";
        public static string PasswordTooShort(int length) => $"As senhas devem conter ao menos {length} caracteres.";

    }
}
