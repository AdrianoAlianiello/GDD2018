using Entities;
using Support;
using System;
using static Support.Constants.Messages;
using System.Linq;
using System.Collections.Generic;

namespace Services
{
    public class LoginService
    {
        private readonly UserService _userService;
        private readonly RoleService _roleService;
        private readonly FunctionalityService _functionalityService;

        public LoginService()
        {
            _userService = new UserService();
            _roleService = new RoleService();
            _functionalityService = new FunctionalityService();
        }

        public void DoLogin(string username, string password)
        {
            var user = _userService.GetByUsername(username);
            if (user == null)
                throw new Exception(MSG_LOGIN_USER_NOT_FOUND);
            else if (!user.Activo)
                throw new Exception(MSG_LOGIN_USER_NOT_ACTIVE);

            VerifyPassword(user, password);

            var roles = _roleService.GetByUser(user.Id);
            if (roles.Count == 0)
                throw new Exception(MSG_LOGIN_USER_WITHOUT_ROLE);

            var functionalities = _functionalityService.GetByRoles(roles.Select(r => r.Id).ToList());
            if (functionalities.Count == 0)
                throw new Exception(MSG_LOGIN_ROLE_WITHOUT_FUNCTIONALITY);

            CurrentUser.SetUser(user.Username, roles.Select(r => r.Nombre).ToArray(), functionalities.Select(f => f.Detalle).ToArray());
        }

        private void VerifyPassword(Usuario user, string password)
        {
            if (user.Password != new SecurityAlgorithmService().Encrypt(password))
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

        public void SelectRole(Rol role)
        {
            var functionalitiesRole = _functionalityService.GetByRoles(new List<int>() { role.Id });
            CurrentUser.SetRoles(new string[1] { role.Nombre });
            CurrentUser.SetFunctionalities(functionalitiesRole.Select(fr => fr.Detalle).ToArray());
        }

        private void UpdateUserAttemps(Usuario user, int attempts)
        {
            user.CantIntentos = attempts;
            _userService.Update(user);
        }

        private void DisableUser(Usuario user)
        {
            user.Activo = false;
            _userService.Update(user);
        }
    }
}
