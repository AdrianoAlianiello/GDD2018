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

        //CLIENT
        public const string MSG_CLIENT_NAME_EMPTY = "El nombre es obligatorio.";
        public const string MSG_CLIENT_SURNAME_EMPTY = "El apellido es obligatorio.";
        public const string MSG_CLIENT_IDENTIFICATION_DOCUMENT_TYPE_EMPTY = "El tipo de documento es obligatorio.";
        public const string MSG_CLIENT_IDENTIFICATION_DOCUMENT_NUMBER_EMPTY = "El número de documento es obligatorio.";
        public const string MSG_CLIENT_CUIL_EMPTY = "El CUIL es obligatorio.";
        public const string MSG_CLIENT_MAIL_EMPTY = "El mail es obligatorio.";
        public const string MSG_CLIENT_PHONE_EMPTY = "El teléfono es obligatorio.";
        public const string MSG_CLIENT_BIRTHDATE_EMPTY = "La fecha de nacimiento es obligatoria.";
        public const string MSG_CLIENT_ADDRESS_STREET_EMPTY = "La calle de domicilio es obligatoria.";
        public const string MSG_CLIENT_ADDRESS_NUMBER_EMPTY = "El número de domicilio es obligatorio.";
        public const string MSG_CLIENT_ADDRESS_FLOOR_EMPTY = "El piso de domicilio es obligatorio.";
        public const string MSG_CLIENT_ADDRESS_DEPARTMENT_EMPTY = "El departamento de domicilio es obligatorio.";
        public const string MSG_CLIENT_ADDRESS_POSTAL_CODE_EMPTY = "El código postal del domicilio es obligatorio.";
        public const string MSG_CLIENT_ADDRESS_CITY_EMPTY = "La localidad de domicilio es obligatoria.";
        public const string MSG_CLIENT_CREDIT_CARD_EMPTY = "Se debe registrar al menos una tarjeta de crédito.";
        public const string MSG_CLIENT_MAIL_INVALID = "El mail ingresado no es válido.";
    }
}
