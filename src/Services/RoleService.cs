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

        public Rol GetById(int id)
        {
            return Context.Session.Read<Rol>(id);
        }
    }
}
