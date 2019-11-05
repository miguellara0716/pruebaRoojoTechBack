using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViajesServer.Commun.Entidades;
using ViajesServer.Commun.Wrappers;
using ViajesServer.Negocio.Interface;
using ViajesServer.Repositorio.Interface;

namespace ViajesServer.Negocio
{
    public class ViajesNegocio : IViajesNegocio
    {
        private readonly IConfiguration _Configuracion;
        private readonly IViajesRepositorio _Repositorio;
        public ViajesNegocio(IConfiguration Configuracion, IViajesRepositorio Repositorio)
        {
            _Configuracion = Configuracion;
            _Repositorio = Repositorio;

        }

        public ParametosViaje obtenerparametro(string nombreParametro)
        {
            return _Repositorio.obtenerparametro(nombreParametro);
        }

        public void RealizarReservaVuelo(VuelosReservas Reserva)
        {
            if (_Repositorio.VerificarVuelosUsuarioDia(Reserva.NumeroCedula))
            {
                _Repositorio.RealizarReservaVuelo(Reserva);
                return;
            }
            throw new Exception("No puede realizar mas de una reserva para el mismo dia.");
            
        }

        public ICollection<Vuelos> ObtenerVuelosDisponibles(long Origen, long Destino, DateTime FechaVuelo)
        {
            ICollection<Vuelos> vuelos = _Repositorio.ObtenerVuelosDisponibles(Origen, Destino, FechaVuelo);
            return vuelos;
        }

        public ICollection<ReservasVuelosUsuarios_Wrapper> ObtenerReservasUsuario(long Documento)
        {
            ICollection<ReservasVuelosUsuarios_Wrapper> reservas = _Repositorio.ObtenerReservasUsuario(Documento);
            return reservas;
        }

        public ICollection<Vuelos> ObtenerTodosVuelosDisponibles()
        {
            return _Repositorio.ObtenerTodosVuelosDisponibles();
        }

    }
}
