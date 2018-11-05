using System.Security.Principal;
using System.Threading;
using static Support.Constants.Configuration;

namespace Support
{
    public static class CurrentUser
    {
        public static string Username { get; private set; }
        public static string Role { get; private set; }
        public static string[] Functionalities { get; private set; }

        public static void SetUser(string username, string role)
        {
            Username = username;
            Role = role;
            Functionalities = new string[1] { FUNCTIONALITY_CREATE_CLIENT };
            AuthenticateInThread();
        }

        private static void AuthenticateInThread()
        {
            Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Username), new string[] { Role });
        }
    }
}
