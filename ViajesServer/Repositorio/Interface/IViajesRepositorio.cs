using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViajesServer.Commun.Entidades;
using ViajesServer.Commun.Wrappers;

namespace ViajesServer.Repositorio.Interface
{
    public interface IViajesRepositorio
    {
        ParametosViaje obtenerparametro(string nombreParametro);
        void RealizarReservaVuelo(VuelosReservas Reserva);

        ICollection<Vuelos> ObtenerVuelosDisponibles(long Origen, long Destino, DateTime FechaVuelo);

        bool VerificarVuelosUsuarioDia(long NumeroCedula);

        ICollection<ReservasVuelosUsuarios_Wrapper> ObtenerReservasUsuario(long Documento);
        ICollection<Vuelos> ObtenerTodosVuelosDisponibles();
    }
}
