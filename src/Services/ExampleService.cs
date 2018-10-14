using Entities;
using Storage;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class ExampleService
    {
        public List<Maestra> GetData()
        {
            return Context.Session.Query<Maestra>().Where(m => m.Apeliido != null && m.CodPostal != null).Take(100).ToList();
        }
    }
}
