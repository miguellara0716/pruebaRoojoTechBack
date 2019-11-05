using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViajesServer.Commun.Entidades
{
    public class VuelosReservas
    {
        public long IdReservaViaje { get; set; }
        public long NumeroCedula { get; set; }
        public long IdVuelo { get; set; }
        public decimal PrecioReserva { get; set; }
    }
}
