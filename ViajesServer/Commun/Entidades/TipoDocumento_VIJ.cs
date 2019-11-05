using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViajesServer.Commun.Entidades
{
    public class TipoDocumento_VIJ
    {
        public short IdTipoDocumento { get; set; }
        public string NombreTipoDocumento { get; set; }
        public long CreadoPor { get; set; }
    }
}
