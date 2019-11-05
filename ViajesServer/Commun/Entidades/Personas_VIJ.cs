using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViajesServer.Commun.Entidades
{
    public class Personas_VIJ
    {
        public long IdPesona { get; set; }
        public string Nombres { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public short TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime FechaExpedicionDoc { get; set; }
        public long CreadoPor { get; set; }
    }
}
