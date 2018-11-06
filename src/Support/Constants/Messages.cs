namespace Support.Constants
{
    public class Messages
    {
        //LOGIN
        public const string MSG_LOGIN_USERNAME_REQUIRED = "El campo usuario es obligatorio.";
        public const string MSG_LOGIN_PASSWORD_REQUIRED = "El campo contraseña es obligatorio.";
        public const string MSG_LOGIN_USER_NOT_FOUND = "El usuario ingresado no existe.";
        public const string MSG_LOGIN_USER_NOT_ACTIVE = "El usuario ingresado no se encuentra activo.";
        public const string MSG_LOGIN_USER_DISABLED = "La cantidad de intentos superó la máxima permitida. Se inhabilito el usuario.";
        public const string MSG_LOGIN_INCORRECT_PASSWORD = "La contraseña ingresada no es válida. Cant. intentos restantes: ";
        public const string MSG_LOGIN_USER_WITHOUT_ROLE = "El usuario no tiene ningun rol asignado.";
        public const string MSG_LOGIN_ROLE_WITHOUT_FUNCTIONALITY = "El rol asociado al usuario no posee ninguna funcionalidad asignada.";

        //USER REGISTRATION
        public const string MSG_USER_REGISTRATION_EXISTING_USERNAME = "El nombre de usuario ya existe. Por favor, ingrese uno nuevo.";
        public const string MSG_USER_REGISTRATION_ERROR_SAVING_USER = "Ha ocurrido un error intentando guardar el usuario.";

    }
}
