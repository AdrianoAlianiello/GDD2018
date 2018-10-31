using Entities;
using Storage;
using Support;
using System;
using System.Linq;
using static Support.Constants.Messages;

namespace Services
{
    public class LoginService
    {
        public void DoLogin(string username, string password)
        {
            var user = Context.Session.Query<Usuario>().Where(u => u.Username == username).First();
            if (user == null)
                throw new Exception(MSG_LOGIN_USER_NOT_FOUND);
            else if (!user.Activo)
                throw new Exception(MSG_LOGIN_USER_NOT_ACTIVE);

            VerifyPassword(user, password);
        }

        private void VerifyPassword(Usuario user, string password)
        {
            if(user.Password != new SecurityAlgorithmService().Encrypt(password))
            {
                var attempts = user.CantIntentos + 1;
                if(attempts > Configuration.MaximumLoginAttempts)
                {
                    DisableUser(user);
                    throw new Exception(MSG_LOGIN_USER_DISABLED);
                }
                else
                {
                    UpdateUserAttemps(user, attempts);
                    var remainingAttempts = Configuration.MaximumLoginAttempts - attempts;
                    throw new Exception(MSG_LOGIN_INCORRECT_PASSWORD + remainingAttempts.ToString());
                }                          
            }
            else
                UpdateUserAttemps(user, 0);
        }

        private void UpdateUserAttemps(Usuario user, int attempts)
        {
            user.CantIntentos = attempts;
            Context.Session.SaveOrUpdate(user);
        }

        private void DisableUser(Usuario user)
        {
            user.Activo = false;
            Context.Session.SaveOrUpdate(user);
        }
    }
}
