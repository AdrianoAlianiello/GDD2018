using Entities;
using Storage;
using System.Collections.Generic;
using System.Linq;
using static Support.Constants.Configuration;

namespace Services
{
    public class RoleService
    {
        public List<Rol> GetPublicRoles()
        {
            return Context.Session.ReadAll<Rol>()
                .Where(rol => rol.Activo && rol.Nombre == ROLE_CLIENT_NAME || rol.Nombre == ROLE_COMPANY_NAME)
                .ToList();
        }

        public List<Rol> GetRolesByName(string[] rolesNames)
        {
            return Context.Session.Query<Rol>()
                .Where(rol => rolesNames.Contains(rol.Nombre))
                .ToList();
        }

        public List<Rol> GetByUser(int userId)
        {
            return Context.Session.Query<RolUsuario>()
                .Join(Context.Session.Query<Rol>(),
                      ru => ru.RolId,
                      r => r.Id,
                      (ru, r) => new { RolUsuario = ru, Rol = r })
                .Where(r => r.Rol.Activo && r.RolUsuario.UsuarioId == userId)
                .Select(r => r.Rol)
                .ToList();          
        }

        public void SaveRolesToUser(int userId, List<Rol> roles)
        {
            var actualRoles = Context.Session.Query<RolUsuario>().Where(ru => ru.UsuarioId == userId).ToList();
            if(actualRoles.Count() > 0)
                Context.Session.DeleteCollection(actualRoles);

            foreach(var role in roles)
            {
                var userRole = new RolUsuario() { RolId = role.Id, UsuarioId = userId };
                Context.Session.SaveOrUpdate(userRole);
            }          
        }
    }
}
