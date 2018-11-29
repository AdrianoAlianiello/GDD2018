using Entities;
using Storage;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class FunctionalityService
    {
        public List<Funcionalidad> GetByRoles(List<int> rolesIds)
        {
            return Context.Session.Query<FuncionalidadRol>()
                .Join(Context.Session.Query<Funcionalidad>(),
                      funcRol => funcRol.FuncionalidadId,
                      func => func.Id,
                      (funcRol, func) => new { funcRol, func })
                .Where(rf => rolesIds.Contains(rf.funcRol.RolId))
                .GroupBy(rf => rf.func.Detalle)
                .Select(rf => rf.ElementAtOrDefault(0).func)
                .ToList();
        }

}
}
