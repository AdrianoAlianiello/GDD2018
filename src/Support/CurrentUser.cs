using System.Security.Principal;
using System.Threading;

namespace Support
{
    public static class CurrentUser
    {
        public static string Username { get; private set; }
        public static string[] Roles { get; private set; }
        public static string[] Functionalities { get; private set; }

        public static void SetUser(string username, string[] roles, string[] functionalities)
        {
            Username = username;
            Roles = roles;
            Functionalities = functionalities;
            AuthenticateInThread();
        }

        private static void AuthenticateInThread()
        {
            if(!Thread.CurrentPrincipal.Identity.IsAuthenticated)
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Username), Roles);
        }

        public static void SetRoles(string[] roles)
        {
            Roles = roles;
            AuthenticateInThread();
        }

        public static void SetFunctionalities(string[] functionalities)
        {
            Functionalities = functionalities;
        }
    }
}
