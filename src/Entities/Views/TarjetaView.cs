using System;

namespace Entities.Views
{
    public class TarjetaView
    {
        public int Id { get; set; }

        public long Numero { get; set; }

        public string Titular { get; set; }

        public DateTime FechaVto { get; set; }

        public int TipoId { get; set; }

        public string TipoNombre { get; set; }
    }
}
