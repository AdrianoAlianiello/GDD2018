using Entities;
using Storage;
using System;
using System.Linq;
using static Support.Constants.Messages;

namespace Services
{
    public class UserService
    {
        public void Update(Usuario user)
        {
            Context.Session.SaveOrUpdate(user);
        }

        public Usuario GetByUsername(string username)
        {
            return Context.Session.Query<Usuario>().Where(u => u.Username == username).First();
        }

        public void CreateUser(Usuario user, Rol role)
        {
            ValidateUser(user);
            SaveUser(user, role);
        }

        private void ValidateUser(Usuario user)
        {
            var existUsername = GetByUsername(user.Username) != null;
            if (existUsername)
                throw new Exception(MSG_USER_REGISTRATION_EXISTING_USERNAME);
        }

        private void SaveUser(Usuario user, Rol role)
        {
            try
            {
                user.Password = new SecurityAlgorithmService().Encrypt(user.Password);
                user.RolId = role.Id;
                user.Temporal = false;
                user.Activo = true;
                user.CantIntentos = 0;
                Context.Session.SaveOrUpdate(user);
            }
            catch
            {
                throw new Exception(MSG_USER_REGISTRATION_ERROR_SAVING_USER);
            }          
        }
    }
}
