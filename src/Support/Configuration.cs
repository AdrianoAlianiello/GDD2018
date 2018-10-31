using System;
using System.Configuration;

namespace Support
{
    public static class Configuration
    {
        //DATABASE
        public readonly static string Server = ConfigurationManager.AppSettings["Server"];
        public readonly static string Database = ConfigurationManager.AppSettings["Database"];
        public readonly static string User = ConfigurationManager.AppSettings["User"];
        public readonly static string Password = ConfigurationManager.AppSettings["Password"];
        public readonly static string Timeout = ConfigurationManager.AppSettings["ConnectionTimeout"];
        //APP
        public readonly static int MaximumLoginAttempts = Convert.ToInt16(ConfigurationManager.AppSettings["MaximumLoginAttempts"]);
    }
}
