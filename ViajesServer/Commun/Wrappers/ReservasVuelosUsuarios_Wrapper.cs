using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViajesServer.Commun.Wrappers
{
    public class ReservasVuelosUsuarios_Wrapper
    {
        public long IdReservaVuelo { get; set; }
        public long DocumentoReserva { get; set; }
        public long IdVuelo { get; set; }
        public string NombreOrigen { get; set; }
        public string NombreDestino { get; set; }
        public DateTime FechaVuelo { get; set; }
        public Decimal PrecioReserva { get; set; }
    }
}
