using System.Collections.Generic;

namespace Entities.DTOs
{
    public class ClienteDTO
    {
        public ClienteDTO()
        {
            Cliente = new Cliente();
            Tarjetas = new List<TarjetaCreditoDTO>();
        }

        public Cliente Cliente { get; set; }

        public List<TarjetaCreditoDTO> Tarjetas { get; set; }
    }
}
