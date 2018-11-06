using Entities;
using Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using static Support.Constants.Messages;

namespace Services
{
    public class UserService
    {
        private readonly RoleService _roleService;

        public UserService()
        {
            _roleService = new RoleService();
        }

        public void Update(Usuario user)
        {
            Context.Session.SaveOrUpdate(user);
        }

        public Usuario GetByUsername(string username)
        {
            return Context.Session.Query<Usuario>().Where(u => u.Username == username).First();
        }

        public void CreateUser(Usuario user, List<Rol> roles)
        {
            ValidateUser(user);
            SaveUser(user, roles);
        }

        private void ValidateUser(Usuario user)
        {
            var existUsername = GetByUsername(user.Username) != null;
            if (existUsername)
                throw new Exception(MSG_USER_REGISTRATION_EXISTING_USERNAME);
        }

        private void SaveUser(Usuario user, List<Rol> roles)
        {
            try
            {
                user.Password = new SecurityAlgorithmService().Encrypt(user.Password);
                user.Temporal = false;
                user.Activo = true;
                user.CantIntentos = 0;
                Context.Session.SaveOrUpdate(user);

                _roleService.SaveRolesToUser(user.Id, roles);

            }
            catch
            {
                throw new Exception(MSG_USER_REGISTRATION_ERROR_SAVING_USER);
            }          
        }
    }
}
