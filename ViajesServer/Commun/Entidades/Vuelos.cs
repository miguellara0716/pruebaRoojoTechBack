using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViajesServer.Commun.Entidades
{
    public class Vuelos
    {
        public long IdVuelo { get; set; }
        public long IdLocalidadOrigen { get; set; }
        public string NombreOrigen { get; set; }
        public long IdLocalidadDestino { get; set; }
        public string NombreDestino { get; set; }
        public int Capacidad { get; set; }
        public int Disponibles { get; set; }
        public DateTime HoraVuelo { get; set; }
        public decimal Precio { get; set; }
    }
}
