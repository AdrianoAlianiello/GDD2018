using System.Collections.Generic;

namespace Entities.DTOs
{
    public class ClienteDTO
    {
        public Cliente Cliente { get; set; }

        public List<TarjetaCreditoDTO> Tarjetas { get; set; }
    }
}
