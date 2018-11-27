using System.Collections.Generic;

namespace Entities.DTOs
{
    public class ClienteRegistracionDTO
    {
        public ClienteRegistracionDTO()
        {
            ClienteDTO = new ClienteDTO();
            Usuario = new Usuario();
            Roles = new List<Rol>();
        }

        public ClienteDTO ClienteDTO { get; set; }

        public Usuario Usuario { get; set; }

        public List<Rol> Roles { get; set; }
    }
}
