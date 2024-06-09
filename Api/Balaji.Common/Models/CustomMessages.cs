namespace Balaji.Common.Models
{
    public class CustomMessages
    {
        public static string? SUCCESS { get; set; } = "Successfully completed !";

        public static string? COMMON_ERROR_MESSAGE { get; } = "Something Went Wrong !";

        public static string? INVALID_FIELD { get; } = "Invalid Field!";

        public static string? CONNECTION_STRING_EMPTY = "Connection string is empty";

        public static string? GET_SESION_FAILUTRE = "Failed ! to get user session";

        public static string? INVALID_SESSION = "Inavalid Session !";
    }
}
