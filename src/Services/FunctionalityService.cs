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
                      (funcRol, func) => func)
                .GroupBy(f => f.Detalle)
                .Select(f => f.ElementAtOrDefault(0))
                .ToList();
        }

}
}
