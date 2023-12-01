namespace FormatTCC.Application.Errors
{
    public class UserErrors
    {

        public readonly static string EmptyUserId = "O id não pode ser vazio";
        public readonly static string EmptyEmail = "O email não pode ser vazio";
        public readonly static string InvalidEmailFormat = "O email não é válido";
        public readonly static string EmptyUserName = "O nome não pode ser vazio";
        public readonly static string EmptyPassword = "A senha não pode ser vazia";
        public readonly static string NewEmptyPassword = "A nova senha não pode ser vazia";
        public readonly static string NotConfirmedPassword = "Por favor confirme sua senha";
        public readonly static string ConfirmedPasswordInvalid = "As senhas informadas não são iguais";
        public readonly static string MinimumPasswordLength = "A senha deve conter pelo menos 6 caracteres";
        public readonly static string EmptyName = "O nome não pode ser vazio";
        public readonly static string EmptySurName = "O sobrenome não pode ser vazio";
        public readonly static string LoginError = "Usuário ou senha inválidos";
        public readonly static string UserAlreadyAuthenticated = "O usuário já está logado, por motivos de segurança você será deslogado";
        public readonly static string NoOneUserAutheticated = "Nenhum usuário está logado no momento";
        public readonly static string DefaultError = "Ocorreu um erro desconhecido.";
        public readonly static string ConcurrencyFailure = "Falha de concorrência otimista, o objeto foi modificado.";
        public readonly static string PasswordMismatch = "Senha incorreta.";
        public readonly static string InvalidToken = "Token inválido.";
        public readonly static string LoginAlreadyAssociated = "Já existe um usuário com este login.";
        public readonly static string UserAlreadyHasPassword = "O usuário já possui uma senha definida.";
        public readonly static string UserLockoutNotEnabled = "O lockout não está habilitado para este usuário.";
        public readonly static string PasswordRequiresNonAlphanumeric = "As senhas devem conter ao menos um caracter não alfanumérico.";
        public readonly static string PasswordRequiresDigit = "As senhas devem conter ao menos um digito ('0'-'9').";
        public readonly static string PasswordRequiresLower = "As senhas devem conter ao menos um caracter em caixa baixa ('a'-'z').";
        public readonly static string PasswordRequiresUpper = "As senhas devem conter ao menos um caracter em caixa alta ('A'-'Z').";
        public readonly static string NotFoundUser = "O usuário não foi encontrado";

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
