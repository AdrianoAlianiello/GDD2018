using System.Configuration;

namespace Storage
{
    public static class Configuration
    {
        public readonly static string Server = ConfigurationManager.AppSettings["Server"];
        public readonly static string Database = ConfigurationManager.AppSettings["Database"];
        public readonly static string User = ConfigurationManager.AppSettings["User"];
        public readonly static string Password = ConfigurationManager.AppSettings["Password"];
        public readonly static string Timeout = ConfigurationManager.AppSettings["ConnectionTimeout"];
    }
}
